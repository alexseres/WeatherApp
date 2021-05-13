using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
            return await ClientManager.RequestForItem<City>(cityName);
            //long num = 1436022000;
            //var e = DateTimeOffset.FromUnixTimeSeconds(num );
            //return city;
        }

        public async Task<ForecastDays> GetNextDays(int cityID)
        {
            return await ClientManager.GetNextDayWeathers<ForecastDays>(cityID);
        }

        

        
    }
}
