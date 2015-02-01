using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace bSeamless.DotNetProg.MVVM.CM.MinimumApp.ViewModels
{
    [ImplementPropertyChanged]
    public class AppViewModel
    {
        public string Message { get; set; }

        public AppViewModel()
        {
            Message = "HI from Caliburn.Micro!";
        }
    }
}
