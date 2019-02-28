using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfClock.Controls
{
	public class AnimatedClock : Control
	{
		public DateTime CurrentDateTime
		{
			get { return (DateTime)GetValue(CurrentDateTimeProperty); }
			set { SetValue(CurrentDateTimeProperty, value); }
		}


		// Using a DependencyProperty as the backing store for currentDateTime.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CurrentDateTimeProperty =
			DependencyProperty.Register(nameof(CurrentDateTime), typeof(DateTime), typeof(AnimatedClock), new PropertyMetadata(default(DateTime)));

		static AnimatedClock()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(AnimatedClock), new FrameworkPropertyMetadata(typeof(AnimatedClock)));
		}
	}
}
