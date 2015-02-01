using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Data;

namespace bSeamless.DotNetProg.Model.V1.Services
{
    public class NHibernateDataService : DataServiceBase
    {
        public NHibernateDataService()
        {
        }

        public override IEnumerable<Employee>  GetEmployees()
        {
            throw new NotImplementedException();
        }
        
        public override Task<IEnumerable<Data.Employee>> GetEmployeesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
