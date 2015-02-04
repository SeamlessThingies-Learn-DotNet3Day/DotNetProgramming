using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace ST.Eg.NSB.WcfIntegration.Shared
{
    public class CancelOrder : ICommand
    {
        public int OrderId { get; set; }
    }
}
