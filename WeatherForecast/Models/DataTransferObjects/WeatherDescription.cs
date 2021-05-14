using Newtonsoft.Json;

namespace WeatherForecast.Models
{
    public class WeatherDescription
    {
        [JsonProperty("main")]
        public string Description { get; set; }
    }
}