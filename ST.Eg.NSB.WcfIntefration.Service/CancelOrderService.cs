using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using ST.Eg.NSB.WcfIntegration.Shared;

namespace ST.Eg.NSB.WcfIntefration.Service
{
    public class CancelOrderService : WcfService<CancelOrder, ErrorCodes>
    {
    }
}
