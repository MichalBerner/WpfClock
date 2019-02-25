using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfClock.Controls
{
	public class Clock : Control
	{
		static Clock()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Clock), new FrameworkPropertyMetadata(typeof(Clock)));
		}

		public DateTime CurrentDateTime
		{
			get { return (DateTime)GetValue(CurrentDateTimeProperty); }
			set { SetValue(CurrentDateTimeProperty, value); }
		}

		// Using a DependencyProperty as the backing store for currentDateTime.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CurrentDateTimeProperty =
			DependencyProperty.Register(nameof(CurrentDateTime), typeof(DateTime), typeof(Clock), new PropertyMetadata(default(DateTime)))	;


	}
}
