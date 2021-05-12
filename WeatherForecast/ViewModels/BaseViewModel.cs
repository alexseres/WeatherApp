using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WeatherForecast.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


    }
}
