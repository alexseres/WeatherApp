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
        private CityDTO cityDTO;

        public CityServiceTest()
        {
            service = new CityService(mockCLient.Object);
            cityDTO =  new CityDTO
            {
                Coordinates = new CoordinatesDTO
                {
                    Latitude = 1,
                    Longitude = 3
                },
                Name = "London",
                ID = 12345,
                Weathers = new List<WeatherDTO>()
                {
                    new WeatherDTO
                    {
                        CurrentWeather = "Sunny"
                    }
                },
                Date = 123231,
                Temperature = new CityTemperatureDTO
                {
                    Temperature = (decimal)25.9
                }
            };

        }

        [Fact]
        public async void CreateCityObject_ShouldReturnCity()
        {
            //Arrange
            var expectedCity = new City
            {
                ID = cityDTO.ID,
                Name = cityDTO.Name
            };

            //Act
            City acutalCity = await service.CreateCityObject(cityDTO);

            //Assert
            Assert.NotNull(acutalCity);
            Assert.Equal(expectedCity.Name, acutalCity.Name);
            Assert.Equal(expectedCity.ID, acutalCity.ID);
        }

        
    }
}
