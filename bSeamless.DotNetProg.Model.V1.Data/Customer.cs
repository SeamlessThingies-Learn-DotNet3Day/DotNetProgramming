using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bSeamless.DotNetProg.Model.V1.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public int SalesPersonId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
    }
}
