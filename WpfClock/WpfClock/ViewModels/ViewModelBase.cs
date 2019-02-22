using System.ComponentModel;

namespace WpfClock.ViewModels
{

	class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
