using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace ST.Eg.NSB.PubSub.Messages
{
    public class EmployeeUpdatedMessage : IEvent
    {
        public string MessageID { get; set; }
        public int EmployeeId { get; set; }
    }
}
