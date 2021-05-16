using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Converters;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public class CityService : ICityService
    {
        public IHttpManager ClientManager { get; set; }

        //this variable just multiplies the temperature because that value is adjusted by the height of an ui element
        private const int temperatureMultiplier = 4;
        public CityService(IHttpManager manager)
        {
            ClientManager = manager;
        }

        public async Task<CityDTO> GetCity(string cityName)
        {
            return await ClientManager.RequestForItem<CityDTO>(cityName);
        }

        public async Task<ForecastDaysDTO> GetNextDays(float lat, float lon)
        {
            return await ClientManager.GetNextDayWeathers<ForecastDaysDTO>(lat, lon);
        }


        public async Task<(CityDTO,ForecastDaysDTO)> GetObjects(string cityName)
        {
            CityDTO cityDTO = await GetCity(cityName);
            ForecastDaysDTO daysDTO = await GetNextDays(cityDTO.Coordinates.Latitude, cityDTO.Coordinates.Longitude);
            return (cityDTO, daysDTO);
        }

        public async Task<City> CreateCityObject(string cityName)
        {
            (CityDTO cityDTO, ForecastDaysDTO daysDTO) =await  GetObjects(cityName);
            City city = new City
            {
                Name = cityDTO.Name,
                ID = cityDTO.ID,
                Temperature = KelvinConverter.ConvertKelvinToCelsius(cityDTO.Temperature.Temperature),
                Weather = cityDTO.Weathers[0].CurrentWeather,
                Date = DayConverter.EpochToDate(cityDTO.Date),
                    
            };
            city.DayOfTheWeek = city.Date.DayOfWeek.ToString();
            city.Days = CreateDaysList(daysDTO);
            return city;
        }

        public ObservableCollection<Day> CreateDaysList(ForecastDaysDTO daysDTO)
        {
            //we need firstdaychecker in order to get rid of the actual day, because we got that in the City object
            ObservableCollection<Day> days = new ObservableCollection<Day>();
            int firstDayChecker = 0;
            foreach (var dayDTO in daysDTO.Days)
            {
                if(firstDayChecker == 0)
                {
                    firstDayChecker++;
                    continue;
                }
                Day day = new Day()
                {
                    ExactDay = DayConverter.EpochToDate(dayDTO.ExactDay),
                    Temperature = KelvinConverter.ConvertKelvinToCelsius(dayDTO.Temperature.Temperature),
                    WeatherDescription = dayDTO.Description[0].Description
                };
                day.TemperatureDisplayValue = day.Temperature * temperatureMultiplier;
                day.DayOfTheWeek = day.ExactDay.DayOfWeek.ToString();
                days.Add(day);
            }
            return days;
        }
    }
}
