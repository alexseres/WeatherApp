using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WeatherForecast.Models
{
    public class City
    {
        public string Name { get; set; }
        public int ID { get; set; } 
        public decimal Kelvin { get; set; }

        public ObservableCollection<Dictionary<string, decimal>> TemperatureOfNext7week { get; set; }
    }
}
