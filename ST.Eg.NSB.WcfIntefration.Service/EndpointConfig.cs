
using System.Diagnostics;

namespace ST.Eg.NSB.WcfIntefration.Service
{
    using NServiceBus;

    /*
		This class configures this endpoint as a Server. 
        More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableInstallers();

            Trace.Listeners.Add(new ConsoleTraceListener());
        }
    }
}
