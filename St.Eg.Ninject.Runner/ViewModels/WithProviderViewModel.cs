using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Services;

namespace St.Eg.Ninject.Runnerr.ViewModels
{
    public class WithProviderViewModel
    {
        public WithProviderViewModel(IDataService service)
        {
            Console.WriteLine("WithProviderViewModel: {0}", service.GetType().Name);
        }
    }


}
