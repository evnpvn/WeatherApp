using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
		//Properties
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

				if (this.CitiesList.Count != 0)
				{
					GetCurrentConditions(this.SearchedCity.Key);
				}			
			}
		}

		public SearchCommand SearchCommand { get; set; }

		public ObservableCollection<City> CitiesList { get; set; }


		//Constructor
		public WeatherVM()
		{
			if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()) == true)
			{
				this.SearchedCity = new City()
				{
					LocalizedName = "New York"
				};
				this.CurrentConditions = new WeatherConditions()
				{
					WeatherText = "Cloudy",
					Temperature = new Temperature()
					{
						Metric = new WeatherUnits
						{
							Value = "10"
						}
					}
				};
			};
			this.SearchCommand = new SearchCommand(this);
			this.CitiesList = new ObservableCollection<City>();
		}


		//INotifyPropertyChanged interface implementation
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


		public async void ExecuteQuery()
		{
			List<City> cities = await AccuWeatherHelper.GetCitiesAsync(this.Query);
			this.CitiesList.Clear();
			
			IEnumerable<City> first4Cities = cities.Take(4);

			foreach(City city in first4Cities)
			{
				this.CitiesList.Add(city);
			}
		}

		private async void GetCurrentConditions(string cityKey)
		{
			//Clear the searchbox
			this.Query = "";

			//Call the async method
			//assign to a weather conditions object
			this.CurrentConditions = await AccuWeatherHelper.GetWeatherConditionsAsync(cityKey);
		}
	}
}