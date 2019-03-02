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
		public const string StartButtonPartName = "PART_StartStopButton";
		public const string StopButtonPartName = "PART_LapResetButton";

		private Button _startButton;
		private Button _stopButton;

		Storyboard _stopWatchStoryboard;
		DoubleAnimation _secondsAnimation;

		static StopWatch()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(StopWatch), new FrameworkPropertyMetadata(typeof(StopWatch)));
		}

		public double Seconds
		{
			get { return (double)GetValue(SecondssProperty); }
			set { SetValue(SecondssProperty, value); }
		}

		public static readonly DependencyProperty SecondssProperty =
			DependencyProperty.Register(nameof(Seconds), typeof(double), typeof(StopWatch), new FrameworkPropertyMetadata(0.0));

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			InitializeStoryboard();

			_startButton = Template.FindName(StartButtonPartName, this) as Button;
			_startButton.Click += StartAnimation;

			_stopButton = Template.FindName(StopButtonPartName, this) as Button;
			_stopButton.Click += StopAnimation;
		}

		private void StopAnimation(object sender, RoutedEventArgs e)
		{
			_stopWatchStoryboard.Pause(this);
			var x = _stopWatchStoryboard.GetCurrentTime(this);
		}

		private void StartAnimation(object sender, RoutedEventArgs e)
		{
			_stopWatchStoryboard.Begin(this, true);
		}

		private void InitializeStoryboard()
		{
			_secondsAnimation = new DoubleAnimation
			{
				From = 0.0,
				To = 60.0,
				Duration = new Duration(TimeSpan.FromSeconds(60))
			};

			Storyboard.SetTargetProperty(_secondsAnimation, new PropertyPath(StopWatch.SecondssProperty));

			_stopWatchStoryboard = new Storyboard();
			_stopWatchStoryboard.Children.Add(_secondsAnimation);
		}
	}
}
