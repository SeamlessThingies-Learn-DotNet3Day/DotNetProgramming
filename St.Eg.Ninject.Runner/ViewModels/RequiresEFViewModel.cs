using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Services;

namespace St.Eg.Ninject.Runnerr.ViewModels
{
    public class RequiresEFViewModel
    {
        public RequiresEFViewModel(IDataService efService)
        {
            Console.WriteLine("RequiresEFViewModel: {0}", efService.GetType().Name);
        }
    }
}
