using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.MVVM.Core;

namespace bSeamless.DotNetProg.Model.V2.Data
{
    public class Employee : ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value != _age)
                {
                    _age = value;
                    notifyPropertyChanged("Age");
                }
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    notifyPropertyChanged("FirstName");
                }
            }
        }

        public Employee()
        {
            
        }
    }
}
