﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfClock.ViewModels;

namespace WpfClock.Views
{
	public class ViewModelLocator
	{
		public ClockPageViewModel ClockPageViewModel => new ClockPageViewModel();
	}
}
