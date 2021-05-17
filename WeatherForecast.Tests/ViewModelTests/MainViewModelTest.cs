using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;
using WeatherForecast.Services;
using WeatherForecast.ViewModels;
using Xunit;

namespace WeatherForecast.Tests.ViewModelTests
{
    public class MainViewModelTest
    {
        public MainViewModel viewModel;
        public Mock<ICityService> mockCityService = new Mock<ICityService>();
        public MainViewModelTest()
        {
            viewModel = new MainViewModel();
        }

        [Fact]
        public void CheckConstructorIfInitializedProperties()
        {
            //Arrange-Act-Assert
            Assert.NotNull(viewModel.ClientManager);
            Assert.NotNull(viewModel.Service);
            Assert.NotNull(viewModel.SearchCommand);
        }

        [Fact]
        public async void SearchRequest_ShouldThrowHttpRequestMessageException_BecauseOfNoInternetConnectiont()
        {
            //Arrange
            viewModel.Service = mockCityService.Object;
            viewModel.SearchInput = "London";
            string cityName = viewModel.SearchInput;
            string expected = "No connection made";

            //Act
            mockCityService.Setup(c => c.CreateAndGetObjects(cityName)).ThrowsAsync(new HttpRequestException("host"));
            viewModel.SearchRequest(new object());

            //Assert
            Assert.Null(viewModel.City);
            Assert.Null(viewModel.Days);
            Assert.Equal(expected, viewModel.ExceptionMessage);
        }

        [Fact]
        public async void SearchRequest_ShouldThrowNullArgumentException_BecauseOfNulObjectReceived()
        {
            //Arrange
            viewModel.Service = mockCityService.Object;
            viewModel.SearchInput = "London";
            string cityName = viewModel.SearchInput;
            string expected = "Some Property is missing, try with another city";

            //Act
            mockCityService.Setup(c => c.CreateAndGetObjects(cityName)).ThrowsAsync(new ArgumentNullException());
            viewModel.SearchRequest(new object());

            //Assert
            Assert.Null(viewModel.City);
            Assert.Null(viewModel.Days);
            Assert.Equal(expected, viewModel.ExceptionMessage);
        }

        [Fact]
        public async void SearchRequest_ShouldThrowHttpRequestMessageException_BecauseOfWrongInput()
        {
            //Arrange
            viewModel.Service = mockCityService.Object;
            viewModel.SearchInput = "Lodnon";
            string cityName = viewModel.SearchInput;
            string expected = "APIkey is wrong or expired";

            //Act
            mockCityService.Setup(c => c.CreateAndGetObjects(cityName)).ThrowsAsync(new HttpRequestException("401"));
            viewModel.SearchRequest(new object());

            //Assert
            Assert.Null(viewModel.City);
            Assert.Null(viewModel.Days);
            Assert.Equal(expected, viewModel.ExceptionMessage);
        }

        [Fact]
        public async void SearchRequest_ShouldinitializeCityAndDaysProperty_WithoutException()
        {
            //Arrange
            viewModel.Service = mockCityService.Object;
            viewModel.SearchInput = "London";
            string cityName = "London";
            City expectedCity = new City
            {
                Date = new DateTime(),
                Name = cityName,
                Days = new System.Collections.ObjectModel.ObservableCollection<Day>()
            };

            //Act
            mockCityService.Setup(c => c.CreateAndGetObjects(cityName)).ReturnsAsync(expectedCity);
            viewModel.SearchRequest(new object());

            //Assert
            Assert.NotNull(viewModel.City);
            Assert.NotNull(viewModel.Days);
            Assert.Equal(cityName, viewModel.City.Name);
            Assert.Equal(expectedCity, viewModel.City);
            mockCityService.Verify(c => c.CreateAndGetObjects(cityName), Times.Once);

        }



    }
}
