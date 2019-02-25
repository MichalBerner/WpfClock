using System.ComponentModel;
namespace WpfClock.Models
{
	class ModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
