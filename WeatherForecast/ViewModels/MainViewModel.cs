using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Converters;
using WeatherForecast.Models;
using WeatherForecast.Services;

namespace WeatherForecast.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private int _doubleTemperatureForDisplay;
        public int DoubleTemperature { get { return _doubleTemperatureForDisplay; } set { SetProperty(ref _doubleTemperatureForDisplay, value); } }

        private City _city;
        public City City { get { return _city; } set { SetProperty(ref _city, value); } }

        private ObservableCollection<Day> _days; 
        public ObservableCollection<Day> Days { get { return _days; } set { SetProperty(ref _days, value); } }

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
                City = await Service.CreateCityObject("Budapest");
                Days = City.Days;
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
