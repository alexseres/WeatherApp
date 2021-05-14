using Moq;
using System;
using System.Collections.Generic;
using System.Text;
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
            mockCityService.Setup(c => c.CreateCityObject(cityName)).ReturnsAsync(expectedCity);
            viewModel.SearchRequest(new object());

            //Assert
            Assert.NotNull(viewModel.City);
            Assert.NotNull(viewModel.City);
            Assert.Equal(cityName, viewModel.City.Name);
            Assert.Equal(expectedCity, viewModel.City);
            mockCityService.Verify(c => c.CreateCityObject(cityName), Times.Once);

        }



    }
}
