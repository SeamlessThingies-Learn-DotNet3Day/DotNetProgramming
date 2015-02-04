using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NServiceBus;
using ST.Eg.NSB.FullDuplex.Shared;

namespace ST.Eg.NSB.FullDuplex.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            var busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName("AddValuesService_Client");
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.EnableInstallers();

            var random = new Random();
            using (var bus = Bus.Create(busConfiguration))
            {
                bus.Start();

                while (!Console.KeyAvailable)
                {
                    Thread.Sleep(1000);

                    var m = new PerformAddCalculationMessage()
                    {
                        Value1 = random.Next(100),
                        Value2 = random.Next(100),
                        DataId = Guid.NewGuid()
                    };
                    bus.Send("AddValuesService_Server", m);
                    
                    // also can do this
                    bus.Send("AddValuesService_Server", m).Register(
                        state =>
                        {
                            Trace.WriteLine("Got response");
                        },
                        null);
                    
                    Trace.WriteLine(string.Format("Sent message: {0} {1}", m.Value1, m.Value2));
                }
            }
        }
    }
}
