using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using Ninject;
using St.Eg.NHibernate.Domain;
using St.Eg.NHibernate.FluentMappings;

namespace St.Eg.NHibernate.Relationships.ConsoleRunner
{
    public class Strategies
    {
        private const string _connString = "server=.\\SQLExpress;database=NH_Eg;Trusted_Connection=True;";
        private StandardKernel _kernel;

        public Strategies()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<ISessionFactory>().ToMethod(c =>
            {
                var sessionFactory =
                    Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012.ConnectionString(_connString))
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>())
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
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>())
                        .BuildSessionFactory();
                return sessionFactory;
            }).InSingletonScope()
                .Named("sessionFactoryShowSql");
        }

        public void ex01_insertCustomerWithOrders()
        {
            createDatabaseFluently();

            var id = 0;
            var sessionFactory = _kernel.Get<ISessionFactory>("sessionFactory");
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var c = createNewCustomerWithOrders();
                Trace.WriteLine("New customer:");
                Trace.WriteLine(c);

                session.Save(c);
                tx.Commit();

                id = c.Id;

            }
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var reloaded = session.Load<Customer>(id);
                Trace.WriteLine("Reloaded");
                Trace.WriteLine(reloaded);
                tx.Commit();
            }
        }

        public void ex02_insertCustomerWithOrders()
        {
            createDatabaseFluently();

            var id = 0;
            var sessionFactory = _kernel.Get<ISessionFactory>("sessionFactory");
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var c = createNewCustomerWithOrders();
                foreach (var o in c.Orders) session.Save(o);
                Trace.WriteLine("New customer:");
                Trace.WriteLine(c);

                session.Save(c);
                tx.Commit();

                id = c.Id;

            }
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var reloaded = session.Load<Customer>(id);
                Trace.WriteLine("Reloaded");
                Trace.WriteLine(reloaded);
                tx.Commit();
            }
        }

        public void ex03_viewCustomersForOrders()
        {
            createDatabaseFluently();
            ex02_insertCustomerWithOrders();

            var id = 1;
            var sessionFactory = _kernel.Get<ISessionFactory>("sessionFactory");
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var customer = session.Load<Customer>(id);
                Trace.WriteLine("Customer");
                Trace.WriteLine(customer);
                Trace.WriteLine("Orders were made by:");
                foreach (var o in customer.Orders)
                {
                    Trace.Write(string.Format("{0}", o.OrderId));
                    if (o.Customer == null) Trace.WriteLine(" Null customer");
                    else
                        Trace.WriteLine(string.Format(" {0} {1} {2}", o.Customer.Id, o.Customer.FirstName,
                            o.Customer.LastName));
                }
                tx.Commit();
            }
        }

        public void ex04_insertCustomerWithOrdersCascading()
        {
            createDatabaseFluently();

            var id = 0;
            var sessionFactory = _kernel.Get<ISessionFactory>("sessionFactory");
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var c = createNewCustomerWithOrders();
                Trace.WriteLine("New customer:");
                Trace.WriteLine(c);

                session.Save(c);
                tx.Commit();

                id = c.Id;

            }
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var reloaded = session.Load<Customer>(id);
                Trace.WriteLine("Reloaded");
                Trace.WriteLine(reloaded);
                tx.Commit();
            }
        }

        public void ex05_deleteCustomerCascading()
        {
            createDatabaseFluently();
            ex04_insertCustomerWithOrdersCascading();

            var sessionFactory = _kernel.Get<ISessionFactory>("sessionFactory");
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var c = session.Load<Customer>(1);
                Trace.WriteLine("Got customer");
                session.Delete(c);
                tx.Commit();
            }
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var customer = session.Query<Customer>().FirstOrDefault();
                if (customer == null) Trace.WriteLine("no customer!");
                var orders = session.Query<Order>().ToList();
                if (orders == null || orders.Count == 0) Trace.WriteLine("Yippee! no orders either");
                tx.Commit();
            }
        }

        public void ex06_fetchWithJoin()
        {
            createDatabaseFluently();
            ex04_insertCustomerWithOrdersCascading();

            var sessionFactory = _kernel.Get<ISessionFactory>("sessionFactory");
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var c = session.Load<Customer>(1);
                Trace.WriteLine("Got customer");
                Trace.WriteLine(c);
                tx.Commit();
            }
        }

        public void ex07_fetchFirst()
        {
            createDatabaseFluently();
            ex04_insertCustomerWithOrdersCascading();

            var sessionFactory = _kernel.Get<ISessionFactory>("sessionFactory");
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var customer = session.Query<Customer>().Where(c => c.Id == 1).Fetch(c => c.Orders).First();
                Trace.WriteLine(customer);
                tx.Commit();
            }
        }

        public void ex08_fetchHorrible()
        {
            createDatabaseFluently();
            ex04_insertCustomerWithOrdersCascading();

            var sessionFactory = _kernel.Get<ISessionFactory>("sessionFactory");
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var customers = session.Query<Customer>().ToList();
                foreach (var customer in customers)
                {
                    Trace.WriteLine(customer);
                    foreach (var order in customer.Orders)
                    {
                        Trace.WriteLine(order);
                    }
                }
                tx.Commit();
            }
        }

        public void ex09_noInverse()
        {
            createDatabaseFluently();
            ex04_insertCustomerWithOrdersCascading();

            var sessionFactory = _kernel.Get<ISessionFactory>("sessionFactory");
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var customer = session.Load<Customer>(1);
                customer.addOrder(new Order() {OrderDate = DateTime.Now});
                session.Save(customer);
                tx.Commit();
            }
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var customer = session.Load<Customer>(1);
                Trace.WriteLine(customer);
                tx.Commit();
            }
        }

        public void ex10_Inverse()
        {
            // set invers on Order

            ex09_noInverse();
        }

        private Customer createNewCustomerWithOrders()
        {
            var c = new Customer()
            {
                FirstName = "Mike",
                LastName = "Heydt",
                HasGoldStatus = true,
                MemberSince = new DateTime(2012, 1, 1),
                CreditRating = CustomerCreditRating.Good,
                ShippingAddress = new ShippingAddress()
                {
                    City = "Missoula",
                    State = "MT",
                },
                Orders = new []
                {
                    new Order()
                    {
                        OrderDate = DateTime.Now
                    },
                    new Order()
                    {
                        OrderDate = DateTime.Now.AddDays(-1),
                        ShippedDate = DateTime.Now,
                        ShippedTo = new ShippingAddress()
                        {
                            City = "Philadelphia",
                            State = "PA"
                        }
                    }
                }
            };
            return c;
        }

        public void createDatabaseFluently()
        {
            Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(_connString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>())
                .ExposeConfiguration(cfg =>
                {
                    var schemaExport = new SchemaExport(cfg);
                    schemaExport.Drop(true, true);
                    schemaExport.Create(true, true);
                })
                .BuildConfiguration();

            Trace.WriteLine("Database dropped and created");
        }
    }
}
