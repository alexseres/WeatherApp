using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WeatherForecast.Models;

namespace WeatherForecast.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private City _city;
        public City City { get { return _city; } set { SetProperty(ref _city, value); } } 

        public Dictionary<string,decimal> Dicti { get; set; }
        public MainViewModel()
        {
            City = new City
            {
                ID = 3,
                Name = "Budapest",
                Kelvin = 300,
/*                TemperatureOfNext7week = new ObservableCollection<Dictionary<string, decimal>>
                {
                    new Dictionary<string, decimal>()
                    {
                        {"Monday", 350 },
                        {"Tuesday", 390 },
                        {"Wednesday", 400 },
                        {"Thursday", 360 },
                        {"Friday", 450 },
                        {"Saturday", 500 },
                        {"Sunday",480  }
                    }
                }*/
            };
            Dicti = new Dictionary<string, decimal>()
            {
                {"Monday", 35 },
                {"Tuesday", 39 },
                {"Wednesday", 40 },
                {"Thursday", 36 },
                {"Friday", 45 },
                {"Saturday", 50 },
                {"Sunday",48  }
            };

        }
    }
}
/*
        < ItemsControl ItemsSource = "{Binding Dicti}" >
 
             < ItemsControl.ItemTemplate >
 
                 < DataTemplate >
 
                     < Canvas Background = "LightCyan" >
  
                          < Rectangle Canvas.Left = "525" Canvas.Top = "225" Height = "200" Width = "42" Fill = "Green" Panel.ZIndex = "3" />
             
                                 </ Canvas >
             
                             </ DataTemplate >
             
                         </ ItemsControl.ItemTemplate >
             
                     </ ItemsControl >
        */