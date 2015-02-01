using bSeamless.DotNetProg.MVVM.CM.MinimumApp.ViewModels;
using Ninject;

namespace bSeamless.DotNetProg.MVVM.CM.MinimumApp
{
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;

    public class NinjectAppBootstrapper : BootstrapperBase
    {
        private StandardKernel _kernel;

        public NinjectAppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IWindowManager>().To<AppWindowManager>().InSingletonScope();
            _kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
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
            DisplayRootViewFor<AppViewModel>();
        }
    }
}