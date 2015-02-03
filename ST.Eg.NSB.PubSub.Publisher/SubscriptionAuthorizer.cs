using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace ST.Eg.NSB.PubSub.Publisher
{
    public class SubscriptionAuthorizer : IAuthorizeSubscriptions
    {
        public SubscriptionAuthorizer()
        {
            Console.WriteLine("Authorizer created");

        }
        public bool AuthorizeSubscribe(string messageType, string clientEndpoint, IDictionary<string, string> headers)
        {
            Console.WriteLine("Authorized subscribe");
            return true;
        }

        public bool AuthorizeUnsubscribe(string messageType, string clientEndpoint, IDictionary<string, string> headers)
        {
            Console.WriteLine("Authorized subscribe");
            return true;
        }
    }
}
