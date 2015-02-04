using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace ST.Eg.NSB.Transactions.Messages
{
    public class NewLocationMessage : ICommand
    {
        public int Id { get; set; }

        public string LocationName { get; set; }
        public string Description { get; set; }

        public NewLocationMessage()
        {
            
        }

        public NewLocationMessage(string locationName, string description)
        {
            LocationName = locationName;
            Description = description;
        }
    }
}
