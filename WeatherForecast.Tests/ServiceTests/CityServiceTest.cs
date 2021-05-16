using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
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

        [Fact]
        public async Task CreateDaysList_ShouldCreateListWithDays()
        {
            //Arrange
            var cityName = "London";

            ForecastDaysDTO daysDTO = new ForecastDaysDTO
            {
                Days = new List<DayDTO>
                {
                    new DayDTO
                    {
                        Description = new List<WeatherDescription>
                        {
                            new WeatherDescription
                            {
                                Description = "Sunny"
                            }
                        },
                        ExactDay = 12234234,
                        Temperature = new ForecastDaysTemperatureDTO
                        {
                            Temperature = 24
                        }
                    },
                    new DayDTO
                    {
                        Description = new List<WeatherDescription>
                        {
                            new WeatherDescription
                            {
                                Description = "Cloudy"
                            }
                        },
                        ExactDay = 12234244,
                        Temperature = new ForecastDaysTemperatureDTO
                        {
                            Temperature = 25
                        }
                    }

                }

            };
            var expectedCount = 1;

            //Act
            ObservableCollection<Day> actualDays = service.CreateDaysList(daysDTO);

            //Assert
            Assert.NotNull(actualDays);
            Assert.Equal(expectedCount, actualDays.Count);
        }
        
    }
}
