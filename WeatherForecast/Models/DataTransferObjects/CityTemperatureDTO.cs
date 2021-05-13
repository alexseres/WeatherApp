using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Models
{
    public class CityTemperatureDTO
    {
        [JsonProperty("temp")]
        public decimal Temperature { get; set; }
    }
}
