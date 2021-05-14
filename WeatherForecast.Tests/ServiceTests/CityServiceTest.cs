using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecast.Services;

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

    }
}
