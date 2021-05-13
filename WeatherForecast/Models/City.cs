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
        public Temperature Kelvin { get; set; }
        public Weather Weather { get; set; }

        public ObservableCollection<Dictionary<string, decimal>> TemperatureOfNext7week { get; set; }
    }
}
