using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Models
{
    public class ForecastDays
    {
        public City City { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
