using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace bSeamless.DotNetProg.MVVM.XAML.Basic.Core
{
    public interface INavigationService
    {
        void Show<T>() where T : UserControl;
        void Show<T>(object parameter) where T : UserControl;
    }
}
