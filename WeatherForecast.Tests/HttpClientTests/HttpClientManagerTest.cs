using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WeatherForecast.Models;
using WeatherForecast.Services;
using Xunit;

namespace WeatherForecast.Tests.HttpClientTests
{
    public class HttpClientManagerTest
    {
        private HttpClientManager manager;

        public HttpClientManagerTest()
        {
            manager = new HttpClientManager();
        }

        [Fact]
        public async void PRocessingRequestForObject_ShouldReturnITem()
        {
            //Arrange
            var url = "https://api.openweathermap.org/data/2.5/weather?q=London&appid=e34c777bb1b5f32880f63683d74ad86d";
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url)
            };
            var expectedName = "London";

            //Act
            var actualItem = await manager.ProcessingRequestForObject<CityDTO>(request);

            //Assert
            Assert.NotNull(actualItem);
            Assert.Equal(expectedName, actualItem.Name);
        }

            [Fact]
        public async void GetNextDayWeathers_ShouldReturnItem()
        {
            //Arrange
            //London's coordinates
            float lat = (float)51.5085;
            float lon = (float)-0.1257;
            int expectedDaysCount = 8;

            //Act
            ForecastDaysDTO actual =  await manager.GetNextDayWeathers<ForecastDaysDTO>(lat, lon);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedDaysCount, actual.Days.Count);
        }

        [Fact]
        public async void RequestForItem_ShouldReturnCityDTO()
        {
            //Arrange
            string cityName = "London";
            int expectedID = 2643743;

            //Act
            CityDTO cityDTO = await manager.RequestForItem<CityDTO>(cityName);

            //Arrange
            Assert.NotNull(cityDTO);
            Assert.Equal(expectedID, cityDTO.ID);

        }

    }
}
