using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public interface IHttpManager<T>
    {
        Task<T> RequestForItem(string Name);
        Task<T> GetNextDayWeathers(int cityID);
    }
}
