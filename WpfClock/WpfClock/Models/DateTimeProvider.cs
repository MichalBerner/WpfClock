﻿using System;
using WpfClock.Interfaces;
using PropertyChanged;
using System.ComponentModel;

namespace WpfClock.Models
{

	internal class DateTimeProvider : ModelBase, IDateTimeProvider
	{
		public DateTime CurrentDateTime { get; private set; } = DateTime.Now;

		public DateTimeProvider()
		{
			System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer
			{
				Interval = TimeSpan.FromSeconds(1)
			};
			timer.Tick += (s, e) => CurrentDateTime = DateTime.Now;
			timer.Start();
		}
	}
}
