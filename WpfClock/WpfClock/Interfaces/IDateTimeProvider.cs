using System;

namespace WpfClock.Interfaces
{
	public interface IDateTimeProvider
	{
		DateTime CurrentDateTime { get; }
	}
}
