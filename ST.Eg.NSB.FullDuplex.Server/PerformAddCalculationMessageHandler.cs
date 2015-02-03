using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Unicast;
using ST.Eg.NSB.FullDuplex.Shared;

namespace ST.Eg.NSB.FullDuplex.Server
{
    public class PerformAddCalculationMessageHandler : IHandleMessages<PerformAddCalculationMessage>
    {
        private IBus _bus;

        public PerformAddCalculationMessageHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(PerformAddCalculationMessage message)
        {
            Trace.WriteLine(string.Format("Received: {0} {1}", message.Value1, message.Value2));
            _bus.Reply<AddCalculationResponseMessage>(rm =>
            {
                rm.DataId = message.DataId;
                rm.Result = message.Value1 + message.Value2;
            });
        }
    }
}
