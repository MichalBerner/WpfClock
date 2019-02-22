using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace WpfClock.Models
{
	class ModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
