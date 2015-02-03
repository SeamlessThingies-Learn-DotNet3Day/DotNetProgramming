using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ST.Eg.NSB.FullDuplex.Shared
{
    public class PerformAddCalculationMessage : NServiceBus.IMessage
    {
        public Guid DataId { get; set; }

        public double Value1 { get; set; }
        public double Value2 { get; set; }
    }
}
