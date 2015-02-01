using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Services;
using Ninject.Activation;

namespace St.Eg.Ninject.Runnerr.Providers
{
    public class DataServiceProvider : Provider<IDataService>
    {
        protected override IDataService CreateInstance(IContext context)
        {
            Console.WriteLine("MockDataServiceProvider.CreateInstance");
            var service = new MockDataService();
            // do complex initialization
            return service;
        }
    }
}
