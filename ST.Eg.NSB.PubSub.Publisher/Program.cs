using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NServiceBus;
using ST.Eg.NSB.PubSub.Messages;

namespace ST.Eg.NSB.PubSub.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            var busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName("PubSub.EmployeeUpdate.Publisher");
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.EnableInstallers();
            var startableBus = Bus.Create(busConfiguration);

            var i = 0;
            using (var bus = startableBus.Start())
            {
                while (!Console.KeyAvailable)
                {
                    Thread.Sleep(1000);

                    var m = new EmployeeUpdatedMessage()
                    {
                        EmployeeId = i++,
                        MessageID = Guid.NewGuid().ToString()
                    };

                    bus.Publish(m);
                    Trace.WriteLine(string.Format("Sent message: {0} {1}", m.MessageID, m.EmployeeId));
                }
            }
        }
    }
}
