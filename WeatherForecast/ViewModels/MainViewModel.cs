using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Converters;
using WeatherForecast.Models;
using WeatherForecast.Services;

namespace WeatherForecast.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Properties

        private string _exceptionMessage;
        public string ExceptionMessage { get { return _exceptionMessage; } set { SetProperty(ref _exceptionMessage, value); } }
        private int _doubleTemperatureForDisplay;
        public int DoubleTemperature { get { return _doubleTemperatureForDisplay; } set { SetProperty(ref _doubleTemperatureForDisplay, value); } }

        private string _searchInput;
        public string SearchInput { get { return _searchInput; } set { SetProperty(ref _searchInput, value); } }

        private City _city;
        public City City { get { return _city; } set { SetProperty(ref _city, value); } }

        private ObservableCollection<Day> _days; 
        public ObservableCollection<Day> Days { get { return _days; } set { SetProperty(ref _days, value); } }

        public IHttpManager ClientManager { get; set; }
        public CityService Service { get; set; }
        #endregion

        #region Commands
        private RelayCommand _searchCommand;
        public RelayCommand SearchCommand { get { return _searchCommand;  } set { SetProperty(ref _searchCommand, value); } }
        #endregion

        public MainViewModel()
        {
            SearchCommand = new RelayCommand(SearchRequest, true);
            ClientManager = new HttpClientManager();
            Service = new CityService(ClientManager);
          
        }

        public async void SearchRequest(object obj)
        {
            if(SearchInput != null)
            {
                try
                {
                    if (ExceptionMessage != null) ExceptionMessage = "";
                    City = await Service.CreateCityObject(SearchInput);
                    Days = City.Days;
                }
                catch(HttpRequestException ex)
                {
                    ExceptionMessage = "There is no such a City";
                    if(City !=null && Days != null)
                    {
                        City = null;
                        Days = null;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }

        }
    }
}
