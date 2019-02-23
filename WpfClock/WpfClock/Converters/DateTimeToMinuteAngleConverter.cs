using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfClock.Converters
{
	class DateTimeToMinuteAngleConverter : IValueConverter
	{
		private const double degreesPerMinute = 6;
		private const double degreesPerSecond = 0.1;

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var dateTime = (DateTime)value;
			var angle = dateTime.Minute * degreesPerMinute + dateTime.Second * degreesPerSecond;
			return angle;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
