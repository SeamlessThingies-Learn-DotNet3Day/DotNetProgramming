using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Interception;

namespace St.Eg.Ninject.Runnerr.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Intercepted");
            invocation.Proceed();
        }
    }
}
