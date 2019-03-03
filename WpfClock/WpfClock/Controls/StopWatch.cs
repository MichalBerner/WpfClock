using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WpfClock.Controls
{
	[TemplatePart(Name = StartStopButtonPartName, Type = typeof(Button))]
	[TemplatePart(Name = LapResetButtonPartName, Type = typeof(Button))]
	public class StopWatch : Control
	{
		public const string StartStopButtonPartName = "PART_StartStopButton";
		public const string LapResetButtonPartName = "PART_LapResetButton";

		private readonly StopWatchState InitialState;
		private readonly StopWatchState RunningState;
		private readonly StopWatchState PausedState;

		private StopWatchState CurrentState;

		private Button _startStopButton;
		private Button _lapResetButton;

		private Storyboard _stopWatchStoryboard;
		private DoubleAnimation _secondsAnimation;

		static StopWatch()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(StopWatch), new FrameworkPropertyMetadata(typeof(StopWatch)));
		}

		public StopWatch()
		{
			InitialState = CreateInitialState();
			RunningState = CreateRunningState();
			PausedState = CreatePausedState();

			CurrentState = InitialState;
		}

		private StopWatchState CreateInitialState()
		{
			return new StopWatchState
			{
				StartStopClicked = () =>
				{
					Start();
					CurrentState = RunningState;
				},
				LapResetClicked = () => { }
			};
		}

		private StopWatchState CreateRunningState()
		{
			return new StopWatchState
			{
				StartStopClicked = () =>
				{
					Pause();
					CurrentState = PausedState;
				},
				LapResetClicked = () =>
				{
					Lap();
				}
			};
		}

		private StopWatchState CreatePausedState()
		{
			return new StopWatchState
			{
				StartStopClicked = () =>
				{
					Resume();
					CurrentState = RunningState;
				},
				LapResetClicked = () =>
				{
					Reset();
					CurrentState = InitialState;
				}
			};
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

			_startStopButton = Template.FindName(StartStopButtonPartName, this) as Button;
			_startStopButton.Click += StartStopButonClicked;

			_lapResetButton = Template.FindName(LapResetButtonPartName, this) as Button;
			_lapResetButton.Click += LapResetButtonClicked;
		}

		private void Pause()
		{
			_stopWatchStoryboard.Pause(this);

		}

		private void Lap()
		{
			var x = _stopWatchStoryboard.GetCurrentTime(this);

		}

		private void Start()
		{
			_stopWatchStoryboard.Begin(this, true);

		}

		private void Reset()
		{
			_stopWatchStoryboard.Stop(this);
		}

		private void Resume()
		{
			_stopWatchStoryboard.Resume(this);
		}

		private void LapResetButtonClicked(object sender, RoutedEventArgs e)
		{
			CurrentState.LapResetClicked();
		}

		private void StartStopButonClicked(object sender, RoutedEventArgs e)
		{
			CurrentState.StartStopClicked();
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
