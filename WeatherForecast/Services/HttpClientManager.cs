using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace WeatherForecast.Services
{
    public class HttpClientManager
    {
        private HttpClient _client;
        public HttpClient Client { get { return _client; } set { _client = value; } }
        public HttpClientManager(HttpClient client)
        {
            Client = client;
        }
    }
}
