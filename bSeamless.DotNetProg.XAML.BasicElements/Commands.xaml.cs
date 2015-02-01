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

namespace bSeamless.DotNetProg.XAML.BasicElements
{
    /// <summary>
    /// Interaction logic for Commands.xaml
    /// </summary>
    public partial class Commands : Window
    {
        private bool _canPress;
        public bool CanPress
        {
            get { return _canPress; }
            set
            {
                if (_canPress != value)
                {
                    _canPress = value;

                    if (_buttonClickedCommand != null)
                        _buttonClickedCommand.canExecuteChanged();
                }
            }
        }

        private MyButtonPressedCommand _buttonClickedCommand;

        public MyButtonPressedCommand ButtonClickedCommand
        {
            get
            {
                if (_buttonClickedCommand == null)
                {
                    _buttonClickedCommand = new MyButtonPressedCommand(this);
                }
                return _buttonClickedCommand;
            }
        }

        public Commands()
        {
            InitializeComponent();

            DataContext = this;

            CanPress = true;
        }

        private void rbEnable_OnClick(object sender, RoutedEventArgs e)
        {
            CanPress = true;
        }

        private void rbDisable_OnClick(object sender, RoutedEventArgs e)
        {
            CanPress = false;
        }
    }

    public class MyButtonPressedCommand : ICommand
    {
        private Commands _parent;
        public MyButtonPressedCommand(Commands parent)
        {
            _parent = parent;
        }

        public bool CanExecute(object parameter)
        {
            return _parent.CanPress;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            MessageBox.Show("I was loosely coupled and pressed!");
        }

        public void canExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, null);
            }
        }
    }
}
