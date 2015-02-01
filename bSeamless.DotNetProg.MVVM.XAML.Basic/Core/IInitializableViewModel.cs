using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bSeamless.DotNetProg.MVVM.XAML.Basic.Core
{
    public interface IInitializableViewModel
    {
        void Initialize(object parameter);
    }
}
