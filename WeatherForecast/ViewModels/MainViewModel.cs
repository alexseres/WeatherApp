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
        public IHttpManager<object> Service { get; set; }
        

        public Dictionary<string,decimal> Dicti { get; set; }
        public MainViewModel()
        {
            Service = new HttpClientManager<object>();
            var city = Service.GetItem<object>("London");

            City = new City
            {
                ID = 3,
                Name = "Budapest",
                Kelvin = 300,
/*                TemperatureOfNext7week = new ObservableCollection<Dictionary<string, decimal>>
                {
                    new Dictionary<string, decimal>()
                    {
                        {"Monday", 350 },
                        {"Tuesday", 390 },
                        {"Wednesday", 400 },
                        {"Thursday", 360 },
                        {"Friday", 450 },
                        {"Saturday", 500 },
                        {"Sunday",480  }
                    }
                }*/
            };
            Dicti = new Dictionary<string, decimal>()
            {
                {"Monday", 30},
                {"Tuesday", 39 },
                {"Wednesday", 40 },
                {"Thursday", 36 },
                {"Friday", 45 },
                {"Saturday", 50 },
                {"Sunday",48  }
            };

        }
    }
}
