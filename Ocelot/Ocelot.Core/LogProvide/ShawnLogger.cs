using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Ocelot.Core.LogProvide
{
    public class ShawnLogger: ILogger
    {
        private readonly string _name;
        private readonly ShanwLoggerConfig _config;

        public ShawnLogger(string name, ShanwLoggerConfig config)
        {
            _name = name;
            _config = config;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var color = Console.ForegroundColor;
            Console.ForegroundColor = _config.Color;
            Console.WriteLine($"{logLevel.ToString()} - {_name} - {formatter(state, exception)}");
            Console.ForegroundColor = color;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
           return logLevel == _config.LogLevel;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }

    public class ShanwLoggerConfig
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
        public ConsoleColor Color { get; set; } = ConsoleColor.Blue;
    }
}
