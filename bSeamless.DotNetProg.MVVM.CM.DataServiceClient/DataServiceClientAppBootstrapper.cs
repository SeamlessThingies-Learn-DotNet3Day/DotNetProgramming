using bSeamless.DotNetProg.Model.V1.Services;
using bSeamless.DotNetProg.MVVM.CM.Common;
using bSeamless.DotNetProg.MVVM.CM.DataServiceClient.Model;
using bSeamless.DotNetProg.MVVM.CM.DataServiceClient.ViewModels;
using bSeamless.DotNetProg.Ninject.V1.Runner;
using Ninject;

namespace bSeamless.DotNetProg.MVVM.CM.DataServiceClient
{
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;

    public class DataServiceClientAppBootstrapper : NinjectAppBootstrapper<
        EventAggregator, AppWindowManager, ShellViewModel>
    {
        private SimpleContainer container;

        public DataServiceClientAppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            base.Configure();

            Kernel.Bind<IAppModel>().To<AppModel>().InSingletonScope();
            Kernel.Bind<IDataService>().To<MockDataService>().InSingletonScope();
            Kernel.Bind<EmployeeDetailViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<EmployeesListViewModel>().ToSelf().InSingletonScope();

            var appModel = Kernel.Get<IAppModel>();
        }
    }
}