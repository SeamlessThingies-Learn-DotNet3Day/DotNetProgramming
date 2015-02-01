using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace bSeamless.DotNetProg.Model.V3.Data
{
    [ImplementPropertyChanged]
    public class Employee
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
    }
}
