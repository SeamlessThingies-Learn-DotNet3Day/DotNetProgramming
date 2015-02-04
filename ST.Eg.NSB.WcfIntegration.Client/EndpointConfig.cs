
using System.Diagnostics;
using NServiceBus;

namespace ST.Eg.NSB.WcfIntefration.Service
{
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableInstallers();

            Trace.Listeners.Add(new ConsoleTraceListener());
        }
    }
}
