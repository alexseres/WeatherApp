using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WeatherForecast.ViewModels
{
    //supports bindings when the source changes dynamically
    public abstract class BaseViewModel : INotifyPropertyChanged
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

        //this raises the event 
        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChangedEventHandler changed = PropertyChanged;
            if (changed == null) return;
            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
