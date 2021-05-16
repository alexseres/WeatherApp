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
        Task<City> CreateAndGetObjects(string searchInput);
        Task<CityDTO> GetCity(string cityName);
        Task<ForecastDaysDTO> GetNextDays(float lat, float lon);
        Task<City> CreateCityObject(CityDTO cityDTO, ForecastDaysDTO daysDTO);
        ObservableCollection<Day> CreateDaysList(ForecastDaysDTO daysDTO);
    }
}
