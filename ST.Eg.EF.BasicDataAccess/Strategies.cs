﻿using System;
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

namespace ST.Eg.EF.BasicDataAccess
{
    public class Strategies
    {
        public Strategies()
        {
            
        }

        public void ex01_GetAllLocations()
        {
            /*
            execute(ctx =>
            {
                var query = ctx.Locations.ToList();

                trace(query);
            });
             * */
        }
        public void ex02_LINQORderBy()
        {
            /*
            execute(ctx =>
            {
                var query = from l in ctx.Locations
                            orderby l.LocationName
                            select l;

                trace(query);
            });
             * */
        }

        public void ex03_Where()
        {
            /*
            execute(ctx =>
            {
                var query = from l in ctx.Locations
                            where l.LocationName == "Australia"
                            orderby l.LocationName
                            select l;

                trace(query);
            });
             * */
        }

        public void ex04_FindById()
        {
            /*
            execute(ctx =>
            {
                // return null if not found
                // also note this is a params[] as compostie keys are supported
                var location = ctx.Locations.Find(1);
                trace(location);
            });
             * */
        }

        public void ex05_SingleOrDefault()
        {
            /*
            execute(ctx =>
            {
                // notice the SQL for this.
                var location = ctx.Locations.SingleOrDefault(l => l.LocationName == "Great Barrier Reef");
                trace(location);
            });
             * */
        }

        public void ex06_LocalCount()
        {
            /*
            execute(ctx =>
            {
                ctx.Locations.ToList();
                // .Local.Count will alway be in memory
                Trace.WriteLine(ctx.Locations.Local.Count.ToString());
            });
             * */
        }

        public void ex07_Load()
        {
            /*
            execute(ctx =>
            {
                // load without iterating
                ctx.Locations.Load();
                // .Local.Count will alway be in memory
                Trace.WriteLine(ctx.Locations.Local.Count.ToString());
            });
             * */
        }

        public void ex08_LoadQuery()
        {
            /*
            execute(ctx =>
            {
                var query =
                    from l in ctx.Locations
                    where l.LocationName == "Australia"
                    select l;

                query.Load();
                Trace.WriteLine(string.Format("{0}", ctx.Locations.Local.Count));
                
            });
             * */
        }

        public void ex09_LocalObservable()
        {
            /*
            execute(ctx =>
            {
                ctx.Locations.Local.CollectionChanged += (s, a) =>
                {
                    if (a.NewItems != null)
                    {
                        foreach (var i in a.NewItems) trace((Location)i, "New: ");
                    }
                    if (a.OldItems != null)
                    {
                        foreach (var i in a.OldItems) trace((Location)i, "Old: ");
                    }
                };
                ctx.Locations.Load();
            });
             * */
        }

        public void ex10_LazyNoLazy()
        {
            /*
            execute(ctx =>
            {
                ctx.Configuration.LazyLoadingEnabled = true;
                var canyon = ctx.Locations.Where(l => l.LocationName == "Grand Canyon").Single();
                if (canyon.Lodgings != null)
                {
                    trace(canyon.Lodgings);
                }
            });
             * */
        }

        public void ex11_EagerLoading()
        {
            /*
            execute(ctx =>
            {
                var destinations = ctx.Locations.Include(l => l.Lodgings);
                trace(destinations);
            });
             * */
        }

        public void ex12_ExplicitLoading()
        {
            /*
            execute(ctx =>
            {
                var canyon = ctx.Locations.Where(l => l.LocationName == "Grand Canyon").Single();
                ctx.Entry(canyon).Collection(d => d.Lodgings).Load();

                Trace.WriteLine("Grand Canyon Lodging");
                trace(canyon.Lodgings);
            });
             * */
        }

        public void ex13_IsLoaded()
        {
            /*
            execute(ctx =>
            {
                var canyon = ctx.Locations.Where(l => l.LocationName == "Grand Canyon").Single();
                var entry = ctx.Entry(canyon);
                Trace.WriteLine(string.Format("Lodgings.IsLoaded: {0}", entry.Collection(d => d.Lodgings).IsLoaded));
                entry.Collection(d => d.Lodgings).Load();
                Trace.WriteLine(string.Format("Lodgings.IsLoaded: {0}", entry.Collection(d => d.Lodgings).IsLoaded));
            });
             * */
        }

        public void ex14_NavPropQueryBad()
        {
            /*
            execute(ctx =>
            {
                var canyon = ctx.Locations.Where(l => l.LocationName == "Grand Canyon").Single();
                var lodgings = canyon.Lodgings.Where(l => l.MilesFromNearestAirport <= 10).ToList();
                trace(lodgings);
            });
             * */
        }

        public void ex15_NavPropQueryGood()
        {
            /*
            execute(ctx =>
            {
                var canyon = ctx.Locations.Where(l => l.LocationName == "Grand Canyon").Single();
                var lquery = ctx.Entry(canyon).Collection(l => l.Lodgings).Query();
                var lodgings = lquery.Where(l => l.MilesFromNearestAirport <= 10).ToList();
                trace(lodgings);
            });
             * */
        }

        public void ex16_JustTheCount()
        {
            /*
            execute(ctx =>
            {
                var canyon = ctx.Locations.Where(l => l.LocationName == "Grand Canyon").Single();
                var count = ctx.Entry(canyon).Collection(l => l.Lodgings).Query().Count();
                Trace.WriteLine(string.Format("Count of lodges at Grand Canyon: {0}", count));
            });
             **/
        }

        /*
        public void ex17_SubsetOfLinkCollection()
        {
            execute(ctx =>
            {
                var canyon = ctx.Locations.Where(l => l.LocationName == "Grand Canyon").Single();
                ctx.Entry(canyon).Collection(l => l.Lodgings).Query().Where(l => l.Name.Contains("Hotel")).Load();
                trace(canyon.Lodgings);
            });
        }
        */
        #region private methods

        private void execute(Action<BreakAwayContext> action)
        {
            using (var ctx = new BreakAwayContext())
            {
                ctx.Database.Log = sql => Trace.WriteLine(sql);
                action(ctx);
            }
        }

        private void execute2(Action<BreakAwayModel2.BreakAwayContext> action)
        {
            using (var ctx = new BreakAwayModel2.BreakAwayContext())
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
