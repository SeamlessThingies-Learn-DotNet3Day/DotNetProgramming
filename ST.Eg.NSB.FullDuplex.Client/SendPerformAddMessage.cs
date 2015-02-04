using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NServiceBus;
using ST.Eg.NSB.FullDuplex.Shared;

namespace ST.Eg.NSB.FullDuplex.Client
{
    public class SendPerformAddMessage : IWantToRunWhenBusStartsAndStops
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
            var random = new Random();
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(1000);

                var m = new PerformAddCalculationMessage()
                {
                    Value1 = random.Next(100),
                    Value2 = random.Next(100),
                    DataId = Guid.NewGuid()
                };
                _bus.Send("ST.Eg.NSB.FullDuplex.Server", m);

                // also can do this
                _bus.Send("ST.Eg.NSB.FullDuplex.Server", m).Register(
                    state =>
                    {
                        Trace.WriteLine("Got response");
                    },
                    null);

                Trace.WriteLine(string.Format("Sent message: {0} {1}", m.Value1, m.Value2));
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
