using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Markup;
using bSeamless.DotNetProg.Model.V1.Data;
using bSeamless.DotNetProg.Model.V1.Services;
using bSeamless.DotNetProg.MVVM.Core;
using bSeamless.DotNetProg.MVVM.XAML.Basic.Core;
using bSeamless.DotNetProg.MVVM.XAML.Basic.Views;

namespace bSeamless.DotNetProg.MVVM.XAML.Basic.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Employee> _employees; 
        public ObservableCollection<Employee> Employees
        {
            get { return _employees;  }
            set
            {
                if (value != _employees)
                {
                    _employees = value;
                    notifyPropertyChanged("Employees");
                }
            }
        }

        private IDataService _dataService;
        private INavigationService _navigationService;

        public MainViewModel(IDataService dataService, INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;

            initializeAsync();
        }

        public async Task initializeAsync()
        {
            var employees = await _dataService.GetEmployeesAsync();
            Employees = new ObservableCollection<Employee>(employees);
        }

        private ICommand _employeeClickedCommand;
        public ICommand EmployeeSelectedCommand
        {
            get
            {
                if (_employeeClickedCommand == null)
                {
                    _employeeClickedCommand = new RelayCommand(p => processEmployeeClicked(p), _ => true);
                }
                return _employeeClickedCommand;
            }
        }

        private void processEmployeeClicked(object selectedItem)
        {
            _navigationService.Show<EmployeeDetailView>(selectedItem);
        }

    }
}
