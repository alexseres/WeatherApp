using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Models
{
    public class ForecastDaysDTO
    {
        public City City { get; set; }

        [JsonProperty("daily")]
        public List<DayDTO> Days { get; set; }
    }
}
