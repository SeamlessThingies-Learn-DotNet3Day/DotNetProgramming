using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.MVVM.XAML.Basic.ViewModels;
using Ninject;
using Ninject.Parameters;

namespace bSeamless.DotNetProg.MVVM.XAML.Basic.Core
{
    public interface IViewModelLocator
    {
        object Parameter { set; }
    }

    public class ViewModelLocator : IViewModelLocator
    {
        public object Parameter { get; set; }

        public StandardKernel Kernel { get; set; }
        public ViewModelLocator()
        {
            // perhaps check for design-time
        }

        public MainViewModel MainViewModel
        {
            get { return Kernel.Get<MainViewModel>(); }
        }

        public EmployeeDetailViewModel EmployeeDetailViewModel
        {
            get
            {
                var vm = Kernel.Get<EmployeeDetailViewModel>();
                if (vm is IInitializableViewModel && Parameter != null)
                {
                    var ivm = vm as IInitializableViewModel;
                    ivm.Initialize(Parameter);
                }

                Parameter = null;

                return vm;
            }
        }
    }
}
