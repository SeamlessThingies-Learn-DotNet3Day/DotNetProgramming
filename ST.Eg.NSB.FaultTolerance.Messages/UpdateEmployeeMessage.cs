using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace ST.Eg.NSB.FaultTolerance.Client
{
    public class UpdateEmployeeMessage : ICommand
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UpdateEmployeeMessage()
        {
            
        }

        public UpdateEmployeeMessage(int id, 
            string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
