using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using ST.Eg.NSB.First.Messages;

namespace ST.Eg.NSB.First.Client
{
    public class SendUpdateEmployee : IWantToRunWhenBusStartsAndStops
    {
        private string[] _names = {"Mike", "Bleu"};

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
            Trace.WriteLine("Press 'Enter' to send message");
            var i = 0;
            while (Console.ReadLine() != null)
            {
                _bus.Send("ST.Eg.NSB.First.Server",
                    new UpdateEmployeeMessage(i, _names[i%2], "Heydt"));
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
