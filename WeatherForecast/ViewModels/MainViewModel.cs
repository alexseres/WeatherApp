using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;
using WeatherForecast.Services;

namespace WeatherForecast.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private City _city;
        public City City { get { return _city; } set { SetProperty(ref _city, value); } }

        private ForecastDays _forecastDays;
        public ForecastDays ForecastDays { get { return _forecastDays; } set { SetProperty(ref _forecastDays, value); } }
        public IHttpManager ClientManager { get; set; }
        public CityService Service { get; set; }

        public Dictionary<string,decimal> Dicti { get; set; }
        public MainViewModel()
        {
            ClientManager = new HttpClientManager();
            Service = new CityService(ClientManager);
            TryGettingMainProperties();
        }

        public async Task<bool> TryGettingMainProperties()
        {
            try
            {
                City = await Service.GetCity("London");
                ForecastDays = await Service.GetNextDays(City.Coordinates.Latitude, City.Coordinates.Latitude);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

    }
}
