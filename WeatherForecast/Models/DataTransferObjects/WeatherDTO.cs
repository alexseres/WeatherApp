using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Models
{
    public class WeatherDTO
    {
        [JsonProperty("main")]
        public string CurrentWeather { get; set; }
    }
}
