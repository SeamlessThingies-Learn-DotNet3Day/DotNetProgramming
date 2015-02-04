using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Data;
using NServiceBus;
using NServiceBus.Unicast;
using Raven.Client;
using Raven.Client.Document;
using ST.Eg.EF.BreakAwayModel;
using ST.Eg.NSB.Transactions.Messages;
using ST.Eg.NSB.Transactions.Server;

namespace ST.Eg.NSB.FaultTolerance.Server
{
    public class NewEmployeeHandler : IHandleMessages<NewLocationMessage>
    {
        private int _retrycount = 0;

        public void Handle(NewLocationMessage message)
        {
            Trace.WriteLine(
                string.Format("Request add new location: {0} {1}",
                                message.LocationName, message.Description));

            var ctx = new BreakAwayEntities();
            ctx.Locations.Add(new Location()
            {
                LocationName = message.LocationName,
                Description = message.Description
            });
            ctx.SaveChanges();

            // throw new Exception("Ooops!");
        }
    }
}
