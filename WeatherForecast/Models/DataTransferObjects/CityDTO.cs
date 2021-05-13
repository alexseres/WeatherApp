using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Models
{
    public class CityDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("main")]
        public CityTemperatureDTO Temperature { get; set; }
        [JsonProperty("weather")]
        public List<WeatherDTO> Weathers { get; set; }
        [JsonProperty("coord")]
        public CoordinatesDTO Coordinates { get; set; }


    }
}
