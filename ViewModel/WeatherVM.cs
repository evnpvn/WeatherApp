using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    class WeatherVM : INotifyPropertyChanged , ICommand
    {
		private string _query;
		public string Query
		{
			get { return _query; }
			set 
			{ 
				_query = value;
				OnPropertyChanged("Query");
			}
		}

		private WeatherConditions _currentConditions;
		public WeatherConditions CurrentConditions
		{
			get { return _currentConditions; }
			set 
			{ 
				_currentConditions = value;
				OnPropertyChanged("CurrentConditions");
			}
		}

		private City _searchedCity;
		public City SearchedCity
		{
			get { return _searchedCity; }
			set 
			{ 
				_searchedCity = value;
				OnPropertyChanged("SearchedCity");
			}
		}

		public WeatherVM()
		{
			if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()) == true)
			{
				SearchedCity = new City()
				{
					LocalizedName = "New York"
				};
				CurrentConditions = new WeatherConditions()
				{
					WeatherText = "Cloudy",
					Temperature = new Temperature()
					{
						Metric = new WeatherUnits
						{
							Value = 10
						}
					}
				};
			}
		}

		//INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;
		public event EventHandler CanExecuteChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		//ICommand implementation
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