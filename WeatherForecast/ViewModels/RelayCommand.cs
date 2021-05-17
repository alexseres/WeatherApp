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

        public RelayCommand(Action<object> execute, bool canExecute) : this(execute, null) { }

        /// <summary>
        /// creates new command
        /// </summary>
        /// <param name="execute">execution logic</param>
        /// <param name="canExecute">can it be executed</param>
        private RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if(execute == null)
            {
                throw new ArgumentNullException();
            }
            this._execute = execute;
            this._canExecute = canExecute;
        }
        
        public event EventHandler CanExecuteChanged
        {
            //pick up the changes that could affect outcome our canexecute
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            //pick up the changes that could affect outcome our canexecute
            return _canExecute == null ? true : _canExecute(parameter);
        }


        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}
