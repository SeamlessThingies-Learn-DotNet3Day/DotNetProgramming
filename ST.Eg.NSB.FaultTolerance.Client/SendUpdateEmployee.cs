using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using ST.Eg.NSB.FaultTolerance.Messages;

namespace ST.Eg.NSB.FaultTolerance.Client
{
    public class SendUpdateEmployee : IWantToRunWhenBusStartsAndStops
    {
        private IBus _bus;
        public IBus Bus
        {
            get { return _bus; }
            set
            {
                _bus = value;
                Trace.WriteLine("_bus set");
            }
        }

        public void Start()
        {
            var i = 0;
            while (true)
            {
                Trace.WriteLine("Press enter to send a message");
                Console.ReadLine();
                _bus.Send("ST.Eg.NSB.FaultTolerance.Server",
                    new UpdateEmployeeMessage(i, "Mike", "Heydt"));
                Trace.WriteLine(string.Format("Sent update for id {0}", i));
                i++;
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
