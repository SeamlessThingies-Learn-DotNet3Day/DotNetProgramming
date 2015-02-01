using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bSeamless.DotNetProg.Model.V1.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public int SalesPerson { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
    }
}
