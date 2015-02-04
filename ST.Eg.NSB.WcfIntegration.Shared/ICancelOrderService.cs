using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ST.Eg.NSB.WcfIntegration.Shared
{
    [ServiceContract(Namespace = "http://nservicebus.com")]
    public interface ICancelOrderService
    {
        [OperationContract()] //Action = "http://nservicebus.com/IWcfServiceOf_CancelOrder_ErrorCodes/Process", ReplyAction = "http://nservicebus.com/IWcfServiceOf_CancelOrder_ErrorCodes/ProcessResponse")]
        ErrorCodes Process(CancelOrder request);
    }
}
