using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Models
{
    public class ForecastDaysTemperature
    {
        [JsonProperty("day")]
        public decimal Kelvin { get; set; }
    }
}
