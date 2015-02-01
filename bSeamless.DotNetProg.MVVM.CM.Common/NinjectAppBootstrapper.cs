using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Ninject;

namespace bSeamless.DotNetProg.MVVM.CM.Common
{
    public class NinjectAppBootstrapper<EA, WM, VM> : BootstrapperBase
        where EA : IEventAggregator
        where WM : IWindowManager
    {
        //private SimpleContainer container;
        private StandardKernel _kernel;
        public StandardKernel Kernel { get { return _kernel; } }

        public NinjectAppBootstrapper()
        {
            _kernel = new StandardKernel();
        }

        protected override void Configure()
        {
            _kernel.Bind<IEventAggregator>().To<EA>().InSingletonScope();
            _kernel.Bind<IWindowManager>().To<WM>().InSingletonScope();
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = _kernel.Get(service);
            if (instance != null)
                return instance;

            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _kernel.GetAll(service);
        }

        protected override void BuildUp(object instance)
        {
            _kernel.Inject(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<VM>();
        }
    }
}
