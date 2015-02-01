using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Services;
using Ninject;

namespace St.Eg.Ninject.Runnerr.ViewModels
{
    public class LazyMockPropertyInjectionViewModel : IInitializable
    {
        private  Lazy<IDataService> _lazyService;

        [Inject]
        public Lazy<IDataService> DataService
        {
            get { return _lazyService; }
            set
            {
                _lazyService = value;
                Console.WriteLine("LazyMockPropertyInjectionViewModel.DataService[set] {0} {1}",
                    _lazyService.Value.GetType().Name,
                    _lazyService.Value.ID);
            }
        }

        public LazyMockPropertyInjectionViewModel()
        {
            Console.WriteLine("LazyMockPropertyInjectionViewModel constructor");
        }

        public void execute()
        {
            Console.WriteLine("executing");
            var x = _lazyService.Value;
        }

        public void Initialize()
        {
            Console.WriteLine("Initialized");
        }
    }
}
