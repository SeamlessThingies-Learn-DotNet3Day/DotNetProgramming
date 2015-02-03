using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace St.Eg.NHibernate.Fundies.ConsoleRunner
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
//                s.ex1_CreateDatabaseNonFluent();
                //s.ex2_CreateDatabaseFluent();
                s.ex3_InsertMultipleCustomers();
                //s.ex4_InsertMultipleCustomersAndShowSql();
                //s.ex5_QueryWithCriteria();
                //s.ex5_QueryWithLinq();
                //s.ex6_QueryAndUpdate();
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
