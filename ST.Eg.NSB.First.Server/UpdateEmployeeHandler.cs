using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Unicast;
using ST.Eg.NSB.First.Messages;

namespace ST.Eg.NSB.First.Server
{
    public class UpdateEmployeeHandler : IHandleMessages<UpdateEmployeeMessage>
    {
        public void Handle(UpdateEmployeeMessage message)
        {
            Trace.WriteLine(
                string.Format("Request to update customer {0}: {1} {2}",
                                message.Id, message.FirstName, message.LastName));
        }
    }
}
