using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace ST.Eg.EF.CodeFirst.BuildDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new InitializeBagaDatabaseWithSeedData());

            QueryLodgingCount();

        }

        private static void QueryLodgingCount()
        {
            using (var context = new BreakAwayContext())
            {
                var canyonQuery = from d in context.Destinations
                                  where d.Name == "Grand Canyon"
                                  select d;

                var canyon = canyonQuery.Single();

                var lodgingQuery = context.Entry(canyon)
                  .Collection(d => d.Lodgings)
                  .Query();

                var lodgingCount = lodgingQuery.Count();
                Console.WriteLine("Lodging at Grand Canyon: " + lodgingCount);
            }
        }
    }
}
