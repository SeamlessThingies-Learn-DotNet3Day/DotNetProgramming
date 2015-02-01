using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V2.Data;
using bSeamless.DotNetProg.MVVM.Core;

namespace bSeamless.DotNetProg.XAML.ItemControls
{
    public class EmployeesViewModel : ViewModelBase
    {
        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get
            {
                return _employees;
            }

            set
            {
                if (value != _employees)
                {
                    _employees = value;
                    notifyPropertyChanged("Employees");
                }
            }
        }

        private Employee _currentEmployee;
        public Employee CurrentEmployee
        {
            get
            {
                return _currentEmployee;
            }
            set
            {
                if (value != _currentEmployee)
                {
                    _currentEmployee = value;
                    notifyPropertyChanged("CurrentEmployee");
                }
            }
        }
    }
}
