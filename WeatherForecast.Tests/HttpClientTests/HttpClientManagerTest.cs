using System;
using System.Collections.Generic;
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

    }
}
