using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Services;

namespace St.Eg.Ninject.Runnerr.ViewModels
{
    public class MockConstructorInjectionViewModel 
    {
        public MockConstructorInjectionViewModel(IDataService service)
        {
            Console.WriteLine("MockConstructorInjectionViewModel: {0} {1}", 
                service.GetType().Name, service.ID);
        }
    }
}
