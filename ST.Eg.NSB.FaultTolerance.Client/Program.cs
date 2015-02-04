using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace ST.Eg.NSB.FaultTolerance.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            var busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName("FaultTolerantClient");
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.EnableInstallers();

            var startableBus = Bus.Create(busConfiguration);

            using (var bus = startableBus.Start())
            {
                var i = 0;
                while (true)
                {
                    Trace.WriteLine("Press enter to send a message");
                    Console.ReadLine();
                    bus.Send("FaultTolerant_Example",
                        new UpdateEmployeeMessage(i, "Mike", "Heydt"));
                    Trace.WriteLine(string.Format("Sent update for id {0}", i));
                    i++;
                }
            }
        }
    }
}
