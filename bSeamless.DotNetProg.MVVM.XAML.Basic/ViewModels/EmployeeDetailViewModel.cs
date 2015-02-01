using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using bSeamless.DotNetProg.Model.V1.Data;
using bSeamless.DotNetProg.MVVM.Core;
using bSeamless.DotNetProg.MVVM.XAML.Basic.Core;
using bSeamless.DotNetProg.MVVM.XAML.Basic.Views;

namespace bSeamless.DotNetProg.MVVM.XAML.Basic.ViewModels
{
    public class EmployeeDetailViewModel : ViewModelBase, IInitializableViewModel
    {
        private Employee _employee;

        public Employee Employee
        {
            get { return _employee; }
            set
            {
                if (_employee != value)
                {
                    _employee = value;
                    notifyPropertyChanged("Employeee");
                }
            }
        }

        private ICommand _saveClickedCommand;
        public ICommand SaveClickedCommand
        {
            get
            {
                if (_saveClickedCommand == null)
                {
                    _saveClickedCommand = new RelayCommand(p => processSaveClicked(), _ => true);
                }
                return _saveClickedCommand;
            }
        }

        private ICommand _cancelClickedCommand;
        public ICommand CancelClickedCommand
        {
            get
            {
                if (_cancelClickedCommand == null)
                {
                    _cancelClickedCommand = new RelayCommand(p => processCancelClicked(), _ => true);
                }
                return _cancelClickedCommand;
            }
        }

        private INavigationService _navigationService;
        public EmployeeDetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Initialize(object parameter)
        {
            Employee = (Employee) parameter;
        }

        private void processSaveClicked()
        {
            _navigationService.Show<MainView>();
        }

        private void processCancelClicked()
        {
            _navigationService.Show<MainView>();
        }

    }
}
