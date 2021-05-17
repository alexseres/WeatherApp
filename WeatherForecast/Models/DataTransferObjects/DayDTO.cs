using System;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Models
{
    public class DayDTO
    {
        [JsonProperty("dt")]
        public int ExactDay { get; set; }

        [JsonProperty("temp")]
        public ForecastDaysTemperatureDTO Temperature { get; set; }

        [JsonProperty("weather")]
        public List<WeatherDescription> Description { get; set; }
    }
}
