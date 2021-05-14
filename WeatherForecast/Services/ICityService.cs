using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public interface ICityService
    {
        Task<CityDTO> GetCity(string cityName);
        Task<ForecastDaysDTO> GetNextDays(float lat, float lon);
        Task<(CityDTO, ForecastDaysDTO)> GetObjects(string cityName);
        Task<City> CreateCityObject(string cityName);
        ObservableCollection<Day> CreateDaysList(ForecastDaysDTO daysDTO);
    }
}
