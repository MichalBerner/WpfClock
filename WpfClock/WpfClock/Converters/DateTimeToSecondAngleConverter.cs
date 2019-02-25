using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfClock.Converters
{
	class DateTimeToSecondAngleConverter : IValueConverter
	{
		private const double degreesPerSecond = 6;

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var dateTime = (DateTime)value;
			var angle = dateTime.Second * degreesPerSecond;
			return angle;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
