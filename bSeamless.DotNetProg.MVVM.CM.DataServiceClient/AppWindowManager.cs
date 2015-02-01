using System.Windows;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bSeamless.DotNetProg.MVVM.CM.DataServiceClient
{
    public class AppWindowManager : WindowManager
    {
        protected override Window EnsureWindow(object model, object view, bool isDialog)
        {
            Window window = base.EnsureWindow(model, view, isDialog);

            window.SizeToContent = SizeToContent.Manual;
            window.Width = 300;
            window.Height = 300;

            return window;
        }
    }
}
