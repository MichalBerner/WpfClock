using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfClock.Converters
{
	class DateTimeToHourAngleConverter : IValueConverter
	{
		private const double degreesPerHour = 30.0;
		private const double degreesPerMinute = 0.5;
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var dateTime = (DateTime)value;
			var angle = dateTime.Hour * degreesPerHour + dateTime.Minute * degreesPerMinute;
			return angle;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
