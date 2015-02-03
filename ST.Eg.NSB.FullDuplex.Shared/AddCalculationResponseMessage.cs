using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace ST.Eg.NSB.FullDuplex.Shared
{
    public class AddCalculationResponseMessage : IMessage
    {
        public Guid DataId { get; set; }
        public double Result { get; set; }
    }
}
