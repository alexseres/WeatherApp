using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Models
{
    public class Day
    {
        public DateTime ExactDay { get; set; }

        public decimal Temperature { get; set; }
        public decimal TemperatureDisplayValue { get; set; }

        public string WeatherDescription { get; set; }

        public string DayOfTheWeek { get; set; }
    }
}
