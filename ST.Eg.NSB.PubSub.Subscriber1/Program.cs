using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using ST.Eg.NSB.PubSub.Messages;
using ST.Eg.NSB.PubSub.Subscriber.Core;

namespace ST.Eg.NSB.PubSub.Subscriber1
{
    public class EmployeeUpdatedMessageHandler : IHandleMessages<EmployeeUpdatedMessage>
    {
        public void Handle(EmployeeUpdatedMessage message)
        {
            Trace.WriteLine(string.Format("Subscriber1 got update for employee: {0} {1}",
                    message.MessageID, message.EmployeeId));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            new BusInitializer("PubSub.EmployeeUpdate.Subscriber1").Bus.Start();
            Trace.WriteLine("Client listening for published messages...");
            Console.ReadLine();
        }
    }
}
