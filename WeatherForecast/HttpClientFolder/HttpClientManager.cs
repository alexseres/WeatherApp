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
    //this client is a communicator with the webapi, request creationd and sending happen here
    public class HttpClientManager :IHttpManager
    {
        private string apiKey = Configs.ApiKey;
        private HttpClient _client;
        public HttpClient Client { get { return _client; } set { _client = value; } }
        public HttpClientManager()
        {
            Client = new HttpClient();
        }

        public async Task<T> RequestForItem<T>(string cityName)
        {
            string url = Configs.CityUrl;
            //Creating request
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"{url}?q={cityName}&appid={apiKey}")
            };
            T item = await ProcessingRequestForObject<T>(request);
            return item;
        }

        public async Task<T> GetNextDayWeathers<T>(float lat, float lon)
        {
            string url = Configs.NextDaysUrl;
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"{url}lat={lat}&lon={lon}&appid={apiKey}")
            };
            T item = await ProcessingRequestForObject<T>(request);
            return item; 
        }

        public async Task<T> ProcessingRequestForObject<T>(HttpRequestMessage request)
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
