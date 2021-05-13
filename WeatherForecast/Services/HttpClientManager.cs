using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Constants;
using WeatherForecast.Converters;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public class HttpClientManager<T> :IHttpManager<T>
    {
        private HttpClient _client;
        public HttpClient Client { get { return _client; } set { _client = value; } }
        public HttpClientManager()
        {
            Client = new HttpClient();
        }

        public async Task<T> RequestForItem(string cityName)
        {
            //sending a request to the API to get the requested city and trying to deserialize it 
            string url = Configs.CityUrl;
            string apiKey = Configs.ApiKey;
            
            try
            {
                var request = new HttpRequestMessage
                {
                    //building the request
                    //RequestUri = new Uri("https://api.openweathermap.org/data/2.5/weather?q=London&appid=e34c777bb1b5f32880f63683d74ad86d"),
                    RequestUri = new Uri($"{url}?q={cityName}&appid={apiKey}")
                };
                using (var response = await Client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    string body = await response.Content.ReadAsStringAsync();
                    T item = JsonConverters<T>.JsonConverter(body);
                    return item;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception();
            }

        }

        public Dictionary<string, decimal> GetNextDayWeathers(string cityName)
        {
            throw new NotImplementedException();
        }
    }

}
