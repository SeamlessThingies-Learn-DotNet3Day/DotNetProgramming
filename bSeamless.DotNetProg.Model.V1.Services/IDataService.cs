using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Data;

namespace bSeamless.DotNetProg.Model.V1.Services
{
    public interface IDataService
    {
        string ID { get; }

        IEnumerable<Employee> GetEmployees();
        Task<IEnumerable<Employee>> GetEmployeesAsync();
    }
}
