using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public interface IHttpManager
    {
        City GetCity(string cityName);
        Dictionary<string, decimal> GetNextDayWeathers(string cityName);
    }
}
