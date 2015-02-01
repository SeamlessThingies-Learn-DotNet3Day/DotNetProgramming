using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Services;
using Ninject.Modules;

namespace St.Eg.Ninject.Runnerr.Modules
{
    public class EFRegistrationModule : NinjectModule
    {
        public override void Load()
        {
            Console.WriteLine("EFRegistrationModule.Load()");

            Bind<IDataService>().To<EFDataService>();
        }
    }
}
