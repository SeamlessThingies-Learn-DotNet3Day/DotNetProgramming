using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Data;
using bSeamless.DotNetProg.Model.V1.Services;
using Ninject;

namespace bSeamless.DotNetProg.Ninject.V1.Runner
{
    public class MockDataService : DataServiceBase
    {
        private IEnumerable<Employee> _employees = new []
        {
            new Employee()
            {
                Id = 2112,
                CompanyName = "bSeamless",
                EmailAddress = "mike@heydt.org", 
                FirstName = "Michael",
                LastName = "Heydt",
                Title = "Founder"
            },
            new Employee()
            {
                Id = 1,
                FirstName = "Marcia",
                LastName = "Heydt",
                Title = "Wife"
            },
            new Employee()
            {
                Id = 2,
                FirstName = "Mikael",
                LastName = "Heydt",
                Title = "Son"
            },
            new Employee()
            {
                Id = 3,
                FirstName = "Bleu",
                LastName = "Heydt",
                Title = "Bleu the Braque D'auvergne"
            }
        };

        public MockDataService()
        {
            Console.WriteLine("Created MockDataService: " + ID);
        }

        /*
        public override IEnumerable<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }
         * */
        public override IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }
        
        public async override Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return _employees; //await new Task<IEnumerable<Employee>>(() => _employees);
        }
    }
}
