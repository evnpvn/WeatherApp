using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherApp.ViewModel.ValueConverters
{
    public class BooltoRain : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //convert from bool to desired string value
            //object as bool and set to a variable
            bool isRaining = (bool)value;

            if (isRaining == true)
            {
                return "Raining";
            }
            else return "No precipitation";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //convert from specified string value to bool
            string IsRaining = value as string;

            if (IsRaining == "Raining" || IsRaining == "Snowing" || IsRaining == "Light Rain")
            {
                return true;
            }
            else return false;

        }
    }
}
