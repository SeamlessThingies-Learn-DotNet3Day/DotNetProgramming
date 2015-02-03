using System;
using System.Collections.Generic;
using NServiceBus;

public class SubscriptionAuthorizer : IAuthorizeSubscriptions
{
    public bool AuthorizeSubscribe(string messageType, string clientEndpoint, IDictionary<string, string> headers)
    {
        Console.WriteLine("---------------- authorize");
        return true;
    }

    public bool AuthorizeUnsubscribe(string messageType, string clientEndpoint, IDictionary<string, string> headers)
    {
        return true;
    }
}