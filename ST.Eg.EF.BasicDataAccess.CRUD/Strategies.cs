using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ST.Eg.EF.BreakAwayModel;

namespace ST.Eg.EF.BasicDataAccess.CRUD
{
    public class Strategies
    {
        public Strategies()
        {
            
        }


        public void ex01_AddNewDestination()
        {
            execute(ctx =>
            {
                var machuPicchu = new Location
                {
                    LocationName = "Machu Picchu2",
                    Country = "Peru"
                };
                ctx.Locations.Add(machuPicchu);
                ctx.SaveChanges();
            });
        }
        
        public void ex02_UpdateGrandCanyon()
        {
            execute(ctx =>
            {
                var canyon = ctx.Locations.Single(l => l.LocationName == "Grand Canyon");
                canyon.Description = "227 Mile Long Canyon";
                ctx.SaveChanges();
            });
        }
        
        public void ex03_DeleteEntity()
        {
            execute(ctx =>
            {
                var bay = ctx.Locations.Single(l => l.LocationName == "Wine Glass Bay");
                ctx.Locations.Remove(bay);
                ctx.SaveChanges();
            });
        }

        
        public void ex04_DeleteWithStub()
        {
            execute(ctx =>
            {
                var todelete = new Location() {LocationID = 6};
                ctx.Locations.Attach(todelete);
                ctx.Locations.Remove(todelete);
                ctx.SaveChanges();
            });
        }
        
        
        public void ex05_DeleteTrip()
        {
            // this is an exception, FK issue, reservation not loaded in memory
            execute(ctx =>
            {
                var trip = ctx.Trips.Single(t => t.Description == "Trip from the database");
                ctx.Trips.Remove(trip);
                ctx.SaveChanges();
            });
        }
        
        public void ex06_DeleteTripOk()
        {
            execute(ctx =>
            {
                var trip = ctx.Trips.Single(t => t.Description == "Trip from the database");
                var res = ctx.Reservations.Single(r => r.Trip.Description == "Trip from the database");
                ctx.Trips.Remove(trip);
                ctx.SaveChanges();
            });
        }
        
        public void ex07_DeleteGrandCanyonWithRelatedLodgings()
        {
            execute(ctx =>
            {
                var canyon = ctx.Locations.Single(l => l.LocationName == "Grand Canyon");
                ctx.Entry(canyon).Collection(l => l.Lodgings).Load();
                ctx.Locations.Remove(canyon);
                ctx.SaveChanges();
                // eager loading ensures the delete
            });
        }
        
        public void ex08_DeleteGrandCanyonLodgingsNotLoaded()
        {
            /*
            execute(ctx =>
            {
                var canyon = ctx.Locations.Single(l => l.LocationName == "Grand Canyon");
                ctx.Locations.Remove(canyon);
                ctx.SaveChanges();
            });
             * */
        }

        public void ex09_CheckForModifiedState()
        {
            execute(ctx =>
            {
                var mp = ctx.Locations.Find(5);
                Trace.WriteLine(ctx.Entry(mp).State);
                mp.Description = "foo";
                Trace.WriteLine(ctx.Entry(mp).State);
            });
        }

        /*
        public void ex01_AddNewDestination()
        {
            execute(ctx =>
            {

            });
        }
        */

        #region private methods

        private void execute(Action<BreakAwayEntities> action)
        {
            using (var ctx = new BreakAwayEntities())
            {
                ctx.Database.Log = sql => Trace.WriteLine(sql);
                action(ctx);
            }
        }

        private void trace(IEnumerable<Location> enumerable, string msg = null)
        {
            foreach (var l in enumerable)
            {
                trace(l, msg);
            }
        }

        private void trace(IOrderedQueryable<Location> query)
        {
            foreach (var l in query)
            {
                trace(l);
            }
        }

        private void trace(Location l, string msg = "")
        {
            if (msg != null) Trace.Write(msg);
            Trace.WriteLine(string.Format("{0}", l.GetType().Name));
            Trace.WriteLine(string.Format("    {0} {1}", l.LocationID, l.LocationName));
        }

        private void trace(IEnumerable<Lodging> enumerable, string msg = null)
        {
            foreach (var l in enumerable)
            {
                trace(l, msg);
            }
        }

        private void trace(Lodging l, string msg)
        {
            if (msg != null) Trace.Write(msg);
            Trace.WriteLine(string.Format("{0}", l.GetType().Name));
            Trace.WriteLine(string.Format("    {0}", l.Name));
        }

        #endregion
    }
}
