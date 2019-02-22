using System;
using WpfClock.Interfaces;
using WpfClock.Models;

namespace WpfClock.ViewModels
{
	internal class MainWindowViewModel : ViewModelBase
	{
		public IDateTimeProvider TimeProvider { get; }

		public MainWindowViewModel()
		{
			TimeProvider = new DateTimeProvider();
		}

	}
}
