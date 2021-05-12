using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WeatherForecast.Models;

namespace WeatherForecast.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private City _city;
        public City City { get { return _city; } set { SetProperty(ref _city, value); } } 
        public MainViewModel()
        {
            City = new City
            {
                ID = 3,
                Name = "Budapest",
                Kelvin = 300
            };

        }
    }
}
