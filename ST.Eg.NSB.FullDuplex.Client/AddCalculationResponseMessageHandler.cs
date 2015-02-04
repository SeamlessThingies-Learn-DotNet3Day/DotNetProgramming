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
    public class AddCalculationResponseMessageHandler : 
        IHandleMessages<AddCalculationResponseMessage>
    {
        public void Handle(AddCalculationResponseMessage message)
        {
            Trace.WriteLine(string.Format("The result is {0} {1}",
                message.DataId, message.Result));
        }
    }
}
