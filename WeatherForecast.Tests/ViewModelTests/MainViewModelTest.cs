using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecast.ViewModels;
using Xunit;

namespace WeatherForecast.Tests.ViewModelTests
{
    public class MainViewModelTest
    {
        public MainViewModel viewModel;
        public MainViewModelTest()
        {
            viewModel = new MainViewModel();
        }

        [Fact]
        public async void CheckConstructorIfInitializedProperties()
        {
            //Arrange-Act-Assert
            Assert.NotNull(viewModel.ClientManager);
            Assert.NotNull(viewModel.Service);
            Assert.NotNull(viewModel.SearchCommand);
        }
    }
}
