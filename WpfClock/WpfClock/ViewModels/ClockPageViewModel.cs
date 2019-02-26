using System;
using WpfClock.Interfaces;
using WpfClock.Models;

namespace WpfClock.ViewModels
{
	internal class ClockPageViewModel : ViewModelBase
	{
		public IDateTimeProvider TimeProvider { get; }

		public ClockPageViewModel()
		{
			TimeProvider = new DateTimeProvider();
		}

	}
}
