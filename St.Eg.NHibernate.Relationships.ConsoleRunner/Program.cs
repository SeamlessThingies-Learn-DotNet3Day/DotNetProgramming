using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace St.Eg.NHibernate.Relationships.ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            NHibernateProfiler.Initialize();

            try
            {
                var s = new Strategies();
                //s.ex1_insertCustomerWithOrders();
                //s.ex2_insertCustomerWithOrders();
                //s.ex3_viewCustomersForOrders();
                //s.ex4_insertCustomerWithOrdersCascading();
                //s.ex5_deleteCustomerCascading();
                //s.ex6_fetchWithJoin();
                //s.ex7_fetchFirst();
                //s.ex8_fetchHorrible();
                //s.ex09_noInverse();
                s.ex10_Inverse();
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
