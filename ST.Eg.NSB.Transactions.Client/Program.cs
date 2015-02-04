using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using ST.Eg.NSB.Transactions.Messages;

namespace ST.Eg.NSB.Transactions.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            var busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName("TransactionProcessing_Client");
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
                    bus.Send("TransactionProcessing_Server",
                        new NewLocationMessage("Paws Up", "The Last Great Place"));
                    Trace.WriteLine(string.Format("Sent update for id {0}", i));
                    i++;
                }
            }

        }
    }
}