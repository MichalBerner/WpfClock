using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WpfClock.Controls
{
	[TemplatePart(Name = StartButtonPartName, Type = typeof(Button))]
	[TemplatePart(Name = StopButtonPartName, Type = typeof(Button))]
	public class StopWatch : Control
	{
		public const string StartButtonPartName = "PART_StartButton";
		public const string StopButtonPartName = "PART_StopButton";

		private Button _startButton;

		static StopWatch()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(StopWatch), new FrameworkPropertyMetadata(typeof(StopWatch)));
		}

		public double Secondss
		{
			get { return (double)GetValue(SecondssProperty); }
			set { SetValue(SecondssProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Seconds.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty SecondssProperty =
			DependencyProperty.Register(nameof(Secondss), typeof(double), typeof(StopWatch), new FrameworkPropertyMetadata(0.0));

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			_startButton = Template.FindName(StartButtonPartName, this) as Button;

			_startButton.Click += StartAnimation;
		}

		private void StartAnimation(object sender, RoutedEventArgs e)
		{

			DoubleAnimation myDoubleAnimation = new DoubleAnimation();
			myDoubleAnimation.From = 0.0;
			myDoubleAnimation.To = 60.0;
			myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(60));
			this.RegisterName( "dupa", this);

			// Configure the animation to target the button's Width property.
			Storyboard.SetTargetName(myDoubleAnimation, "dupa");
			Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(StopWatch.SecondssProperty));

			// Create a storyboard to contain the animation.
			Storyboard myWidthAnimatedButtonStoryboard = new Storyboard();
			myWidthAnimatedButtonStoryboard.Children.Add(myDoubleAnimation);
			myWidthAnimatedButtonStoryboard.Begin(this);


		}
	}
}
