using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace St.Eg.NHibernate.Query.ConsoleRunner
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
                //s.ex01_GetVsLoad();
                //s.ex02_getThenLoadSameObject();
                //s.ex03_addGetVsLoad();
                //s.ex04_LINQ();
                //s.ex05_HQL();
                s.ex06_CriteriaQuery();
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
