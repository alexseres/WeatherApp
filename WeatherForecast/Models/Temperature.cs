using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Models
{
    public class Temperature
    {
        [JsonProperty("temp")]
        public decimal Kelvin { get; set; }
    }
}
