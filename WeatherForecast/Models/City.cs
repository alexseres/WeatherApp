using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Models
{
    public class City
    {
       
        public string Name { get; set; }
        public int ID { get; set; }
        public decimal Temperature { get; set; }
        public List<Day> Days { get; set; }

        public string Weather { get; set; }
    }
}
