using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WeatherForecast.Models;
using WeatherForecast.Services;

namespace WeatherForecast.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private City _city;
        public City City { get { return _city; } set { SetProperty(ref _city, value); } }
        public IHttpManager<object> ClientManager { get; set; }
        public CityService Service { get; set; }

        public Dictionary<string,decimal> Dicti { get; set; }
        public MainViewModel()
        {
            ClientManager = new HttpClientManager<object>();
            Service = new CityService(ClientManager);
            var city = Service.GetCity("London");
            
        }
    }
}
