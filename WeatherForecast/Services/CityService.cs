using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public class CityService
    {
        public IHttpManager<object> ClientManager { get; set; }
        public CityService(IHttpManager<object> manager)
        {
            ClientManager = manager;
        }

        public City GetCity(string cityName)
        {
            var city = ClientManager.RequestForItem(cityName);
            return new City { };
        }
    }
}
