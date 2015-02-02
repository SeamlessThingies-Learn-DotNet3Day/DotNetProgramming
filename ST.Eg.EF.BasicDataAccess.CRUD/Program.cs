using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Eg.EF.BasicDataAccess.CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            try
            {
                var s = new Strategies();
                //s.ex01_AddNewDestination();
                //s.ex02_UpdateGrandCanyon();
                //s.ex03_DeleteEntity();
                //s.ex05_DeleteTrip();
                //s.ex06_DeleteTripOk();
                //s.ex07_DeleteGrandCanyonWithRelatedLodgings();
                s.ex09_CheckForModifiedState();
                
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
