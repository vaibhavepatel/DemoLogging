using System;
using Serilog.Core;
using Serilog.Events;

namespace DemoLogging.Service
{
    public class CustomEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("LogTime", DateTime.UtcNow));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("TransactionId", Guid.NewGuid()));
        }
    }
}
