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

        public async Task<City> CreateAndGetObjects(string searchInput)
        {
            CityDTO cityDTO= await GetCity(searchInput);
            ForecastDaysDTO daysDTO = await GetNextDays(cityDTO.Coordinates.Latitude, cityDTO.Coordinates.Longitude);
            City city = await CreateCityObject(cityDTO, daysDTO);
            return city;
        }

        public async Task<CityDTO> GetCity(string cityName)
        {
            return await ClientManager.RequestForItem<CityDTO>(cityName);
        }

        public async Task<ForecastDaysDTO> GetNextDays(float lat, float lon)
        {
            return await ClientManager.GetNextDayWeathers<ForecastDaysDTO>(lat, lon);
        }


        public async Task<City> CreateCityObject(CityDTO cityDTO,ForecastDaysDTO daysDTO)
        {

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
                ColorInitializer(ref day);
                day.DayOfTheWeek = day.ExactDay.DayOfWeek.ToString();
                days.Add(day);
            }
            return days;
        }

        public void ColorInitializer(ref Day day)
        {

            if(day.Temperature >= 35)
            {
                day.ColumnColor = "FireBrick";
            }
            else if(day.Temperature < 35 && day.Temperature >= 30)
            {
                day.ColumnColor = "Red";
            }
            else if (day.Temperature < 30 && day.Temperature >= 25)
            {
                day.ColumnColor = "Tomato";
            }
            else if (day.Temperature < 25 && day.Temperature >= 20)
            {
                day.ColumnColor = "Salmon";
            }
            else if (day.Temperature < 20 && day.Temperature >= 15)
            {
                day.ColumnColor = "Purple";
            }
            else if (day.Temperature < 15 && day.Temperature >= 10)
            {
                day.ColumnColor = "LightSkyBlue";
            }
            else
            {
                day.ColumnColor = "Blue";
            }
        }
    }
}
