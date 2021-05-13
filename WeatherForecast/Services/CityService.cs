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

        public async Task<City> GetCity(string cityName)
        {
            var city = await ClientManager.RequestForItem<City>(cityName);
            var converted = DayConverter.EpochToDate(city.Kelvin.Kelvin);
            return city;
        }

        public async Task<ForecastDays> GetNextDays(float lat, float lon)
        {
            return await ClientManager.GetNextDayWeathers<ForecastDays>(lat, lon);
        }

        

        
    }
}
