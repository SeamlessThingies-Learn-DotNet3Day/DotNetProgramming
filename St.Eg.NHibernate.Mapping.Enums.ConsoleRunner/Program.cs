using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace St.Eg.NHibernate.Mapping.Enums.ConsoleRunner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            NHibernateProfiler.Initialize();

            try
            {
                var s = new Strategies();
                s.ex1_createCustomerWithEnum();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Exception");
                Trace.WriteLine(ex.Message);
                if (ex.InnerException != null) Trace.WriteLine(ex.InnerException.Message);
            }

            Console.ReadLine();
        }

    }
}

