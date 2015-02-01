using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bSeamless.DotNetProg.XAML.Other.Debugging
{
    public class Person : BindableBase
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (value != _name)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }


        public Address Address { get; set; }
        public Person()
        {
            this.Address = new Address() { Number = 1, Street = "Main Street" };
        }
    }
}
