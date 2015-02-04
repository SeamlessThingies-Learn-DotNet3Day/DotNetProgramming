using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using ST.Eg.NSB.WcfIntegration.Shared;

namespace ST.Eg.NSB.WcfIntefration.Service
{
    public class CancelOrderHandler : IHandleMessages<CancelOrder>
    {
        public void Handle(CancelOrder message)
        {
            Trace.WriteLine(string.Format("Got message to cancel order: {0}", 
                message.OrderId));
        }
    }
}
