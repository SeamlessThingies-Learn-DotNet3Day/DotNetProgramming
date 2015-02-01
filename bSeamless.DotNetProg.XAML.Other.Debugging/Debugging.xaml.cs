using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace bSeamless.DotNetProg.XAML.Other.Debugging
{
    /// <summary>
    /// Interaction logic for Debugging.xaml
    /// </summary>
    public partial class Debugging : Window
    {
        public Debugging()
        {
            InitializeComponent();

            var person = new Person();
            DataContext = person;
        }
    }
}
