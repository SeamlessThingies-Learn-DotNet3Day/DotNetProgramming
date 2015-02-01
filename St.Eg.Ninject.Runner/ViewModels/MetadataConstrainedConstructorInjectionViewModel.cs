using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Services;
using bSeamless.DotNetProg.Model.V1.Services.Constraints;

namespace St.Eg.Ninject.Runnerr.ViewModels
{
    public class MetadataConstrainedConstructorInjectionViewModel
    {
        public MetadataConstrainedConstructorInjectionViewModel(
            [MockAccessTechnique] 
//            [EFAccessTechnique] 
//            [MessagingAccessTechnique] 
            IDataService service)
        {
            Console.WriteLine("MetadataConstrainedConstructorInjectionViewModel: {0}", service.GetType().Name);
        }
    }
}
