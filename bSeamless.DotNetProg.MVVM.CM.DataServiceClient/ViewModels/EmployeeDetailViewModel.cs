using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Data;
using bSeamless.DotNetProg.MVVM.CM.DataServiceClient.Events;
using Caliburn.Micro;

namespace bSeamless.DotNetProg.MVVM.CM.DataServiceClient.ViewModels
{
    public class EmployeeDetailViewModel : Screen
    {
        private IEventAggregator _eventAggregator;

        private Employee _employee;
        public Employee Employee
        {
            get { return _employee; }
            set
            {
                //if (value != _employee)
                {
                    _employee = value;
                    NotifyOfPropertyChange(() => Employee);
                }
            }
        }

        public EmployeeDetailViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void saveEmployeeDetails()
        {
            this.TryClose();
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            // need to force this due to reuse of the view model
            NotifyOfPropertyChange("Employee");
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
        }
    }
}
