using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace bSeamless.DotNetProg.MVVM.XAML.Basic.Core
{
    public interface IShell
    {
        void ShowContent(UserControl control);
    }
}
