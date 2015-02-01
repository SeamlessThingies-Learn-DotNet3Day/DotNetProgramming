using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Data;

namespace bSeamless.DotNetProg.Model.V1.Services
{
    // this class should be abstract, but for purposes of
    // Ninject interception, abstract prevents proxy creation;
    public class DataServiceBase : IDataService
    {
        public string ID { get; private set; }

        public DataServiceBase()
        {
            ID = Guid.NewGuid().ToString();
        }

        //public abstract IEnumerable<Data.Employee> GetEmployees();
        public virtual IEnumerable<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public async virtual Task<IEnumerable<Data.Employee>> GetEmployeesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
