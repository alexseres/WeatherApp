using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Constants;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public class HttpClientManager<T> : IHttpManager
    {
        private HttpClient _client;
        public HttpClient Client { get { return _client; } set { _client = value; } }
        public HttpClientManager(HttpClient client)
        {
            Client = client;
        }

        public async Task<T> GetCity(string cityName)
        {
            string url = Configs.CityUrl;
            string apiKey = Configs.ApiKey;
            
            try
            {
                var request = new HttpRequestMessage
                {
                    //RequestUri = new Uri("https://api.openweathermap.org/data/2.5/weather?q=London&appid=e34c777bb1b5f32880f63683d74ad86d"),
                    RequestUri = new Uri($"{url}?q={cityName}&appid={apiKey}")
                };
                using (var response = await Client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return body;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public Dictionary<string, decimal> GetNextDayWeathers(string cityName)
        {
            throw new NotImplementedException();
        }
    }

}
