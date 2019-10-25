using System;
using Microsoft.Extensions.Logging;

namespace UselessProject
{
	class UselessLogger: ILogger
	{
		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			if (IsEnabled(logLevel))
			{
				switch (logLevel)
				{
					case LogLevel.Trace:
						Console.WriteLine("Trace");
						break;
					case LogLevel.Debug:
						Console.WriteLine("Debug");
						break;
					case LogLevel.Information:
						Console.WriteLine("Information");
						break;
					case LogLevel.Warning:
						Console.WriteLine("Warning");
						break;
					case LogLevel.Error:
						Console.WriteLine("Error");
						break;
					case LogLevel.Critical:
						Console.WriteLine("Critical");
						break;
					case LogLevel.None:
						Console.WriteLine("None");
						break;
					default:
						throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
				}
			}

		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return false;
		}

		public IDisposable BeginScope<TState>(TState state)
		{
			return null;
		}
	}
}
