using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Services;
using Ninject.Modules;

namespace St.Eg.Ninject.Runnerr.Modules
{
    class MockRegistrationModule : NinjectModule
    {
        public override void Load()
        {
            Console.WriteLine("MockRegistrationModule.Load()");
            Bind<IDataService>().To<MockDataService>();
        }
    }
}
