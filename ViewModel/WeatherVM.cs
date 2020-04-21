using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Model;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
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

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


		public async void CreateQuery()
		{
			List<City> cities = await AccuWeatherHelper.GetCitiesAsync(Query);
		}

		///ICommand implementation
		//public event EventHandler CanExecuteChanged;

		//public bool CanExecute(object parameter)
		//{
		//	throw new NotImplementedException();
		//}

		//public void Execute(object parameter)
		//{
		//	List<City> cities = AccuWeatherHelper.GetCitiesAsync((parameter as WeatherVM).Query).Result;

		//	City city = cities.FirstOrDefault();

		//	WeatherConditions weatherConditions = AccuWeatherHelper.GetWeatherConditionsAsync(city.Key).Result;
		//}
	}
}