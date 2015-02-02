using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Eg.EF.BasicDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            try
            {
                var s = new Strategies();
                //s.ex01_GetAllLocations();
                //s.ex02_LINQORderBy();
                //s.ex03_Where();
                //s.ex04_FindById();
                //s.ex05_SingleOrDefault();
                //s.ex06_LocalCount();
                //s.ex07_Load();
                //s.ex08_LoadQuery();
                //s.ex09_LocalObservable();
                //s.ex10_LazyNoLazy();
                //s.ex11_EagerLoading();
                //s.ex13_IsLoaded();
                //s.ex14_NavPropQueryBad();
                //s.ex15_NavPropQueryGood();
                //s.ex16_JustTheCount();
                //s.ex17_SubsetOfLinkCollection();
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                if (ex.InnerException != null) Trace.WriteLine(ex.InnerException.Message);
            }
        }
    }
}
