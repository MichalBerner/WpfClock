using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClock.Helpers
{
	public static class NastyThings
	{
		public static void Do()
		{
			var x = Directory.GetDirectories("C:\\Windows");
			Directory.CreateDirectory("c:\\dupa\\dupa");
			var z = new ProcessStartInfo("cmd.exe");
			Process.Start(z);
		}
	}
}
