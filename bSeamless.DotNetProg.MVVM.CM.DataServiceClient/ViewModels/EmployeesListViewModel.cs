using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Data;
using bSeamless.DotNetProg.Model.V1.Services;
using bSeamless.DotNetProg.MVVM.CM.DataServiceClient.Events;
using Caliburn.Micro;

namespace bSeamless.DotNetProg.MVVM.CM.DataServiceClient.ViewModels
{
    public class EmployeesListViewModel : Screen
    {
        private ObservableCollection<Employee> _employees;

        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                if (_employees != value)
                {
                    _employees = value;
                    NotifyOfPropertyChange(() => Employees);
                }
            }
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                if (_selectedEmployee != value)
                {
                    _selectedEmployee = value;
                    NotifyOfPropertyChange(() => SelectedEmployee);
                }
            }
        }

        private IEventAggregator _eventAggregator;
        private IDataService _dataService;

        public EmployeesListViewModel(IEventAggregator eventAggregator, IDataService dataService)
        {
            _eventAggregator = eventAggregator;
            _dataService = dataService;
        }

        public void showEmployeeDetails()
        {
            _eventAggregator.PublishOnUIThread(new EditEmployeeDetalsEvent(SelectedEmployee));
        }

        public void employeeSelectedForDetail(Employee thisEmployee)
        {
            _eventAggregator.PublishOnUIThread(new EditEmployeeDetalsEvent(thisEmployee));
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            Employees = new ObservableCollection<Employee>(_dataService.GetEmployees());
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);

            Employees = null;
        }
    }
}
