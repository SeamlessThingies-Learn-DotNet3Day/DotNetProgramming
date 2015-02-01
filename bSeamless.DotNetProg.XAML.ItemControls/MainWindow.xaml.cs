using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using bSeamless.DotNetProg.Model.V2.Data;

namespace bSeamless.DotNetProg.XAML.ItemControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeesViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();

            _vm = new EmployeesViewModel()
            {
                Employees = new ObservableCollection<Employee>()
                {
                    new Employee() {FirstName = "Mike", Age = 35},
                    new Employee() {FirstName = "Bleu", Age = 1},
                }
            };

            DataContext = _vm;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.Employees.Add(new Employee() {FirstName = "Mikael", Age = 17});
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _vm.Employees.Remove(_vm.CurrentEmployee);
        }
    }
}
