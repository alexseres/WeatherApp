using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Converters;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public class CityService
    {
        public IHttpManager ClientManager { get; set; }
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
            try
            {
                CityDTO cityDTO = await GetCity(cityName);
                ForecastDaysDTO daysDTO = await GetNextDays(cityDTO.Coordinates.Latitude, cityDTO.Coordinates.Longitude);
                return (cityDTO, daysDTO);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentException();
                Console.WriteLine(ex);
            }
        }


        public List<Day> CreateDaysList(ForecastDaysDTO daysDTO)
        {
            List<Day> days = new List<Day>();
            foreach (var dayDTO in daysDTO.Days)
            {
                Day day = new Day()
                {
                    ExactDay = DayConverter.EpochToDate(dayDTO.ExactDay),
                    Temperature = dayDTO.Temperature.Temperature
                };
                days.Add(day);
            }
            return days;
        }

        public async Task<City> CreateCityObject(string cityName)
        {
            (CityDTO cityDTO, ForecastDaysDTO daysDTO) =await  GetObjects(cityName);
            try
            {
                City city = new City
                {
                    Name = cityDTO.Name,
                    ID = cityDTO.ID,
                    Temperature = KelvinConverter.ConvertKelvinToCelsius(cityDTO.Temperature.Temperature),
                    Weather = cityDTO.Weathers[0].ToString()
                };
                city.Days = CreateDaysList(daysDTO);
                return city;
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }

    }
}
