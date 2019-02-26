using System.ComponentModel;

namespace WpfClock.ViewModels
{

	public class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
