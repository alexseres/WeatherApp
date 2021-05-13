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
        private string url = Configs.CityUrl;
        private string apiKey = Configs.ApiKey;
        private HttpClient _client;
        public HttpClient Client { get { return _client; } set { _client = value; } }
        public HttpClientManager()
        {
            Client = new HttpClient();
        }

        public async Task<T> RequestForItem(string cityName)
        {
            //Creating request
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"{url}?q={cityName}&appid={apiKey}")
            };
            return await ProcessingRequestForObject(request);
        }

        public Dictionary<string, decimal> GetNextDayWeathers(int cityID)
        {
            
        }

        public async Task<T> ProcessingRequestForObject(HttpRequestMessage request)
        {
            //send the created request and deserialzie it
            using (var response = await Client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                T item = JsonConverters<T>.JsonConverter(body);
                return item;
            }
        }

    }

}
