using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace ST.Eg.NSB.Transactions.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            var busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName("TransactionProcessing_Server");
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.EnableInstallers();

            using (var bus = Bus.Create(busConfiguration))
            {
                bus.Start();
                Trace.WriteLine("Listening for requests");
                Console.ReadLine();
            }
        }
    }
}
