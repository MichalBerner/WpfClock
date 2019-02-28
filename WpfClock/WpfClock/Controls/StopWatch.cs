using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WpfClock.Controls
{
	[TemplatePart(Name = StartButtonPartName, Type = typeof(Button))]
	[TemplatePart(Name = StopButtonPartName, Type = typeof(Button))]
	public class StopWatch : Control
	{
		//todo: still needs some work :)
		public const string StartButtonPartName = "PART_StartButton";
		public const string StopButtonPartName = "PART_StopButton";

		private Button _startButton;
		private Button _stopButton;

		Storyboard _myWidthAnimatedButtonStoryboard;
		DoubleAnimation _myDoubleAnimation;

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

			_stopButton = Template.FindName(StopButtonPartName, this) as Button;
			_stopButton.Click += StopAnimation;
		}

		private void StopAnimation(object sender, RoutedEventArgs e)
		{
			_myWidthAnimatedButtonStoryboard.Pause(this);
			//BeginAnimation(StopWatch.SecondssProperty, null);
		}

		private void StartAnimation(object sender, RoutedEventArgs e)
		{

			_myDoubleAnimation = new DoubleAnimation();
			_myDoubleAnimation.From = 0.0;
			_myDoubleAnimation.To = 60.0;
			_myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(60));

			//this.BeginAnimation(StopWatch.SecondssProperty, _myDoubleAnimation);

			Storyboard.SetTargetProperty(_myDoubleAnimation, new PropertyPath(StopWatch.SecondssProperty));

			_myWidthAnimatedButtonStoryboard = new Storyboard();
			_myWidthAnimatedButtonStoryboard.Children.Add(_myDoubleAnimation);
			_myWidthAnimatedButtonStoryboard.Begin(this, true);

		}
	}
}
