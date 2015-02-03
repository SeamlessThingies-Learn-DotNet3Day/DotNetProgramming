using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Impl;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using Ninject;
using St.Eg.NHibernate.Fundies.ConsoleRunner.Domain;

namespace St.Eg.NHibernate.Fundies.ConsoleRunner
{
    public class Strategies
    {
        private const string _connString = "server=.\\SQLExpress;database=NH_Eg01;Trusted_Connection=True;";
        private StandardKernel _kernel;

        public Strategies()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<ISessionFactory>().ToMethod(c =>
            {
                var sessionFactory =
                    Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012.ConnectionString(_connString))
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                        .BuildSessionFactory();
                return sessionFactory;
            }).InSingletonScope()
            .Named("sessionFactory");

            _kernel.Bind<ISessionFactory>().ToMethod(c =>
            {
                var sessionFactory =
                    Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012.ConnectionString(_connString)
                            .ShowSql())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                        .BuildSessionFactory();
                return sessionFactory;
            }).InSingletonScope()
            .Named("sessionFactoryShowSql");
        }

        public void ex1_CreateDatabaseNonFluent()
        {
            /*
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = _connString;
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
            });
            cfg.AddAssembly(typeof (Customer).Assembly);

            var m = cfg.GetClassMapping(typeof (Customer));
            var se = new SchemaExport(cfg);
            se.Drop(true, true);
            se.Create(true, true);

            Trace.WriteLine("Database dropped and created");
             * */
        }

        public void ex2_CreateDatabaseFluent()
        {
            /*
            Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString(_connString))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                    .ExposeConfiguration(cfg =>
                    {
                        var schemaExport = new SchemaExport(cfg);
                        schemaExport.Drop(true, true);
                        schemaExport.Create(true, true);
                    })
                    .BuildConfiguration();

            Trace.WriteLine("Database dropped and created");
             * */
        }

        public void ex3_InsertMultipleCustomers()
        {
            /*
            var sessionFactory = _kernel.Get<ISessionFactory>("sessionFactory");
            var customers = new List<Customer>();
            using (var session = sessionFactory.OpenSession())
            {
                var names = new[] {"Mike", "Marcia", "Mikael", "Blue", "Tagg"};
                names.ToList().ForEach(name =>
                {
                    var customer = new Customer()
                    {
                        FirstName = name,
                        LastName = "Heydt"
                    };
                    customers.Add(customer);
                    session.Save(customer);
                });
            }

            Trace.WriteLine("Saved customers");

            // Id's are assigned
            customers.ForEach(c => Trace.WriteLine(c));
             * */
        }

        public void ex4_InsertMultipleCustomersAndShowSql()
        {
            /*
            var sessionFactory = _kernel.Get<ISessionFactory>("sessionFactoryShowSql");

            var customers = new List<Customer>();
            using (var session = sessionFactory.OpenSession())
            {
                var names = new[] { "Mike", "Marcia", "Mikael", "Bleu", "Tagg" };
                names.ToList().ForEach(name =>
                {
                    var customer = new Customer()
                    {
                        FirstName = name,
                        LastName = "Heydt"
                    };
                    customers.Add(customer);
                    session.Save(customer);
                });
            }

            Trace.WriteLine("Saved customers");

            // Id's are assigned
            customers.ForEach(c => Trace.WriteLine(c));
             * */
        }

        public void ex5_QueryWithCriteria()
        {
            /*
            var sessionFactory = _kernel.Get<ISessionFactory>("sessionFactory");
            using (var session = sessionFactory.OpenSession())
            {
                var customers = session.CreateCriteria<Customer>().List<Customer>();
                customers.ToList().ForEach(c => Trace.WriteLine(c));
            }
             * */
        }
        public void ex5_QueryWithLinq()
        {
            /*
            var sessionFactory = _kernel.Get<ISessionFactory>("sessionFactory");
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var customers = session.Query<Customer>()
                    .OrderBy(c => c.FirstName);
                customers.ToList().ForEach(c => Trace.WriteLine(c));
                tx.Commit();
            }
             * */
        }

        public void ex6_QueryAndUpdate()
        {
            /*
            ex2_CreateDatabaseFluent();
            ex3_InsertMultipleCustomers();

            var sessionFactory = _kernel.Get<ISessionFactory>("sessionFactory");
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var customer = session.Query<Customer>()
                    .First(c => c.FirstName == "Mike");
                Trace.WriteLine(customer);
                customer.FirstName = "Cosmo";
                session.Update(customer);
                tx.Commit();
            }
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var customers = session.Query<Customer>();
                customers.ToList().ForEach(c => Trace.WriteLine(c));
                tx.Commit();
            }
             * */
        }
    }
}
