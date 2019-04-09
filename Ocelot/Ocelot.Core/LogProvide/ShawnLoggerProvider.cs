using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Ocelot.Core.LogProvide
{
    public class ShawnLoggerProvider:ILoggerProvider
    {
        private readonly ShanwLoggerConfig _config;

        public ShawnLoggerProvider(ShanwLoggerConfig config)
        {
            _config = config;
        }

        public void Dispose()
        {
            
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new ShawnLogger(categoryName, _config);
        }
    }
}
