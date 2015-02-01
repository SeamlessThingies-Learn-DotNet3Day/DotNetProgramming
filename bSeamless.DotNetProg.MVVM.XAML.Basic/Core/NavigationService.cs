using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Ninject.Parameters;

namespace bSeamless.DotNetProg.MVVM.XAML.Basic.Core
{
    public class NavigationService : INavigationService
    {
        private IShell _shell;
        private IViewModelLocator _viewModelLocator;

        public NavigationService(IShell shell, IViewModelLocator viewModelLocator)
        {
            _shell = shell;
            _viewModelLocator = viewModelLocator;
        }

        public void Show<T>() where T : UserControl
        {
            // code things in here like a back-stack
            // wire up, ...
            var uc = Activator.CreateInstance<T>();
            _shell.ShowContent(uc);
        }
        public void Show<T>(object parameter) where T : UserControl
        {
            // code things in here like a back-stack
            // wire up, ...

            _viewModelLocator.Parameter = parameter;

            var uc = Activator.CreateInstance<T>();
            _shell.ShowContent(uc);
        }
    }
}
