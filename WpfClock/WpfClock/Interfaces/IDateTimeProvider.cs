using System;

namespace WpfClock.Interfaces
{
	interface IDateTimeProvider
	{
		DateTime CurrentDateTime { get; }
	}
}
