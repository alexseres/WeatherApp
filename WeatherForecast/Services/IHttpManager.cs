using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public interface IHttpManager
    {
        Task<T> RequestForItem<T>(string Name);
        Task<T> GetNextDayWeathers<T>(float lat, float lon);
    }
}
