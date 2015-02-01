using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.MVVM.CM.DataServiceClient.Events;
using Caliburn.Micro;

namespace bSeamless.DotNetProg.MVVM.CM.DataServiceClient.ViewModels
{
    public class ShellViewModel : Conductor<object>,
                IHandle<EditEmployeeDetalsEvent>,
                IHandle<EditEmployeeDetailFinishedEvent>

    {
        private IEventAggregator _eventAggregator;
        private EmployeesListViewModel _employeesListViewModel;
        private EmployeeDetailViewModel _employeeDetailViewModel;

        public ShellViewModel(
            IEventAggregator eventAggregator,
            EmployeesListViewModel employeesListViewModel,
            EmployeeDetailViewModel employeeDetailViewModel)
        {
            _eventAggregator = eventAggregator;
            _employeeDetailViewModel = employeeDetailViewModel;
            _employeesListViewModel = employeesListViewModel;

            _eventAggregator.Subscribe(this);

            showEmployeeList();
        }

        public void showEmployeeList()
        {
            ActivateItem(_employeesListViewModel);
        }

        public void showEmployeeDetail()
        {
            ActivateItem(_employeeDetailViewModel);
        }

        public void Handle(EditEmployeeDetalsEvent message)
        {
            _employeeDetailViewModel.Employee = message.Employee;
            showEmployeeDetail();
        }

        public void Handle(EditEmployeeDetailFinishedEvent message)
        {
            showEmployeeList();
        }

        public override void DeactivateItem(object item, bool close)
        {
            base.DeactivateItem(item, close);

            if (item == _employeeDetailViewModel)
            {
                showEmployeeList();
            }
        }
    }

}
