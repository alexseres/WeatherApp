using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public interface IHttpManager<T>
    {
        Task<T> GetItem(string Name);
        Dictionary<string, decimal> GetNextDayWeathers(string cityName);
    }
}
