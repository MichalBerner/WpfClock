using System;
using WpfClock.Interfaces;

namespace WpfClock.Models
{
	class DateTimeProvider : ModelBase, IDateTimeProvider
	{
		public DateTime CurrentDateTime { get; private set; } = DateTime.Now;

		public DateTimeProvider()
		{
			var timer = new System.Windows.Threading.DispatcherTimer
			{
				Interval = TimeSpan.FromSeconds(1)
			};
			timer.Tick += (s, e) => CurrentDateTime = DateTime.Now;
		}
	}
}
