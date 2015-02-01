using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using bSeamless.DotNetProg.Model.V1.Services;
using bSeamless.DotNetProg.MVVM.XAML.Basic.Core;
using bSeamless.DotNetProg.MVVM.XAML.Basic.ViewModels;
using bSeamless.DotNetProg.MVVM.XAML.Basic.Views;
using bSeamless.DotNetProg.Ninject.V1.Runner;
using Ninject;

namespace bSeamless.DotNetProg.MVVM.XAML.Basic
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private StandardKernel _kernel;
        public StandardKernel Kernel { get { return _kernel; } }

        // dont use this!
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            _kernel = new StandardKernel();
            _kernel.Bind<MainViewModel>().ToSelf();
            _kernel.Bind<IDataService>().To<MockDataService>().InSingletonScope();

            var vml = this.FindResource("ViewModelLocator") as ViewModelLocator;
            vml.Kernel = _kernel;

            var shell = new Shell();
            var navigationService = new NavigationService(shell, vml);

            _kernel.Bind<INavigationService>().ToConstant(navigationService);

            shell.Show();

            navigationService.Show<MainView>();
        }
    }
}
