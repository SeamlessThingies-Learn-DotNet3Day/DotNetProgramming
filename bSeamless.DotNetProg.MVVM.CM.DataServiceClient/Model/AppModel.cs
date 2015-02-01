using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using bSeamless.DotNetProg.Model.V1.Services;

namespace bSeamless.DotNetProg.MVVM.CM.DataServiceClient.Model
{
    public interface IAppModel
    {
        ObservableCollection<string> ServiceNames { get; }
        IDataService DataService { get;  }
    }

    public class AppModel : IAppModel
    {
        private ObservableCollection<string> _serviceNames; 
        public ObservableCollection<string> ServiceNames
        {
            get { return _serviceNames; }
            set { _serviceNames = value; }
        }


        public IDataService DataService { get; private set; }

        public AppModel(IDataService dataService)
        {
            DataService = dataService;

            _serviceNames = new ObservableCollection<string>(
                new List<string>(new [] {"Mock", "NServiceBus"}));
        }
    }
}
