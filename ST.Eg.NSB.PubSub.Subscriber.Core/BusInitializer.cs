using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace ST.Eg.NSB.PubSub.Subscriber.Core
{
    public class BusInitializer
    {
        public IStartableBus Bus { get; private set; }

        public BusInitializer(string endpointName)
        {
            var busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName(endpointName);
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.EnableInstallers();
            Bus = NServiceBus.Bus.Create(busConfiguration);
        }
    }
}
