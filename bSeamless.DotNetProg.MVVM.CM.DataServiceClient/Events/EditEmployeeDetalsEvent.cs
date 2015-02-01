using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Data;

namespace bSeamless.DotNetProg.MVVM.CM.DataServiceClient.Events
{
    public class EditEmployeeDetalsEvent
    {
        public Employee Employee { get; private set; }

        public EditEmployeeDetalsEvent(Employee employee)
        {
            Employee = employee;
        }
    }
}
