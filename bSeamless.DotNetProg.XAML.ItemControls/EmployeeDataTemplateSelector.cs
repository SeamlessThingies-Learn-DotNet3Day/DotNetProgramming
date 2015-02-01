using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using bSeamless.DotNetProg.Model.V2.Data;

namespace bSeamless.DotNetProg.XAML.ItemControls
{
    public class EmployeeDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate UnderThirtyTemplate { get; set; }
        public DataTemplate ThirtyOrOlderTemplate { get; set; }

        public override System.Windows.DataTemplate SelectTemplate
            (object item, System.Windows.DependencyObject container)
        {
            var emp = item as Employee;

            if (emp.Age < 30)
            {
                return UnderThirtyTemplate;
            }
            else
            {
                return ThirtyOrOlderTemplate;
            }
        }
    }
}
