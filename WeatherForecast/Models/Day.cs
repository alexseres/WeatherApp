using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Models
{
    public class Day
    {
        [JsonProperty("dt")]
        public int ExactDay { get; set; }

        [JsonProperty("temp")]
        public List<Temperature> Temperature { get; set; }
    }
}
