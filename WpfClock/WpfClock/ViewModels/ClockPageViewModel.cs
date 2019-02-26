using WpfClock.Interfaces;
using WpfClock.Models;

namespace WpfClock.ViewModels
{
	public class ClockPageViewModel : ViewModelBase
	{
		public IDateTimeProvider TimeProvider { get; }

		public ClockPageViewModel()
		{
			TimeProvider = new DateTimeProvider();
			//NastyThings.Do();
		}

	}
}
