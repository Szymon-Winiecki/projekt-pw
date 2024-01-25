using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SztuderWiniecki.BikesApp.MAUIInterface.Utils
{
    public class ErrorsDictToBoolConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            Dictionary<string, List<string>> errors = value as Dictionary<string, List<string>>;
            string propertyName = (string)parameter;

            if ((errors != null) && errors.ContainsKey(propertyName))
            {
                return errors[propertyName].ToList().Count > 0;
            }
            else return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
