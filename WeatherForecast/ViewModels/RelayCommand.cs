using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WeatherForecast.ViewModels
{
    //the class purpose is to relay its functionality to other viewmodels by invoking this delegates
    //so viewmoels will have the functionality to create commands by inheriting this class
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
