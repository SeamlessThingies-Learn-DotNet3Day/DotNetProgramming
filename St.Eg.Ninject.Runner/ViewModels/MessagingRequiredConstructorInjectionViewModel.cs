using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Services;
using St.Eg.Ninject.Runnerr.Constraints;

namespace St.Eg.Ninject.Runnerr.ViewModels
{
    [MessagingRequired] 
    public class MessagingRequiredConstructorInjectionViewModel
    {
        public MessagingRequiredConstructorInjectionViewModel(IDataService service)
        {
            Console.WriteLine("MessagingRequiredConstructorInjectionViewModel: {0}",
                service.GetType());
        }
    }
}
