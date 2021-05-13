using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WeatherForecast.Models
{
    public class City
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("main")]
        public Temperature Kelvin { get; set; }
        [JsonProperty("weather")]
        public List<Weather> Weathers { get; set; }
        [JsonProperty("coord")]
        public Coordinates Coordinates { get; set; }

        public Weather Weather { get; set; }

    }
}
