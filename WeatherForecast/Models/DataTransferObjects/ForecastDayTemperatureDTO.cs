using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Models
{
    public class ForecastDaysTemperatureDTO
    {
        [JsonProperty("day")]
        public decimal Temperature { get; set; }
    }
}
