using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Models
{
    public class ForecastDays
    {
        public City City { get; set; }

        [JsonProperty("daily")]
        public List<Day> Days { get; set; }
    }
}
