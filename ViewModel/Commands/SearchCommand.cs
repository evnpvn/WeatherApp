using System;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        //Properties
        public WeatherVM VM { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SearchCommand(WeatherVM vm)
        {
            VM = vm;
        }

        //ICommand inherited interface implementation
        public bool CanExecute(object parameter)
        {
            string query = parameter as string;
            if (string.IsNullOrWhiteSpace(query) == false)
            {
                return true;
            }
            else return false;
        }

        public void Execute(object parameter)
        {
            VM.ExecuteQuery();
        }
    }
}