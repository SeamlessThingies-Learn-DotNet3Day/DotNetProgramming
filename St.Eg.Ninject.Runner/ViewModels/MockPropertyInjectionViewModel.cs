using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Services;
using Ninject;

namespace St.Eg.Ninject.Runnerr.ViewModels
{
    public class MockPropertyInjectionViewModel
    {
        private IDataService _service;
        [Inject]
        public IDataService DataService
        {
            get { return _service; }
            set
            {
                _service = value;
                Console.WriteLine("MockPropertyInjectionViewModel.DataService[set] {0} {1}",
                    _service.GetType().Name,
                    _service.ID);
            }
        }
        public MockPropertyInjectionViewModel()
        {
            Console.WriteLine("MockPropertyInjectionViewModel constructor");
        }
    }
}
