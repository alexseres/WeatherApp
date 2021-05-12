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

        //creates new command
        public RelayCommand(Action<object> execute, bool canExecute) : this(execute, null) { }

        private RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if(execute == null)
            {
                throw new ArgumentNullException();
            }
            this._execute = execute;
            this._canExecute = canExecute;
        }
        

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
