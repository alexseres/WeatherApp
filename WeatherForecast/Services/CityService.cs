using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public class CityService
    {
        public IHttpManager<City> ClientManager { get; set; }
        public CityService(IHttpManager<City> manager)
        {
            ClientManager = manager;
        }

        public async Task<City> GetCity(string cityName)
        {
            var city = await ClientManager.RequestForItem(cityName);
            return new City { };
        }
    }
}
