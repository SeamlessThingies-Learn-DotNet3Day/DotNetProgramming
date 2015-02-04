using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Unicast;
using ST.Eg.NSB.FaultTolerance.Messages;

namespace ST.Eg.NSB.FaultTolerance.Server
{
    public class UpdateEmployeeHandler : IHandleMessages<UpdateEmployeeMessage>
    {
        static private int _count = 0;

        public UpdateEmployeeHandler()
        {
            Trace.WriteLine("New UpdateEmployeeHandler");
        }
        public void Handle(UpdateEmployeeMessage message)
        {
            Trace.WriteLine(
                string.Format("Request... to update customer {0}: {1} {2}",
                                message.Id, message.FirstName, message.LastName));

            _count++;
            Trace.WriteLine(string.Format("Count=={0}", _count));
            if (_count == 4)
                throw new Exception("Database is down");
        }
    }
}
