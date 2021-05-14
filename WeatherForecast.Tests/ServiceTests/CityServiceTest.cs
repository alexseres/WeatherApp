using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecast.Models;
using WeatherForecast.Services;
using Xunit;

namespace WeatherForecast.Tests.ServiceTests
{
    public class CityServiceTest
    {
        private CityService service;
        private Mock<IHttpManager> mockCLient = new Mock<IHttpManager>();

        public CityServiceTest()
        {
            service = new CityService(mockCLient.Object);
        }

        [Fact]
        public async void GetObjects_ShouldReturnObjects()
        {
            //Arrange
            string cityName = "London";
            float lat = (float)51.5085;
            float lon = (float)-0.1257;
            CityDTO expectedCityDTO = new CityDTO
            {
                Name = "London",
                ID = 2643743,
            };
            ForecastDaysDTO forecastDaysDTO = new ForecastDaysDTO
            {
                City = new City()
            };

            //Act
            mockCLient.Setup(c => c.RequestForItem<CityDTO>(cityName)).ReturnsAsync(expectedCityDTO);
            mockCLient.Setup(c => c.GetNextDayWeathers<ForecastDaysDTO>(lat, lon)).ReturnsAsync(forecastDaysDTO);
            await service.GetCity(cityName);
            await service.GetNextDays(lat, lon);
            (CityDTO actualCityDTO, ForecastDaysDTO actualForecastDaysDTO ) = await service.GetObjects(cityName);

            //Assert
            Assert.NotNull(actualCityDTO);
            //Assert.NotNull(actualForecastDaysDTO);
        }

    }
}
