using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WeatherForecast.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //sets new value to the property if it has changed, invoked in child class
        protected virtual bool SetProperty<T>(ref T stored, T newValue, [CallerMemberName] string propertyName = null)
        {
            if(EqualityComparer<T>.Default.Equals(stored, newValue)) return false;

            stored = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
