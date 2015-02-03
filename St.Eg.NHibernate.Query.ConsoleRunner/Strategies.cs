using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using Ninject;
using St.Eg.NHibernate.Domain;
using St.Eg.NHibernate.FluentMappings;
using NHibernate.Proxy;
using Order = St.Eg.NHibernate.Domain.Order;

namespace St.Eg.NHibernate.Query.ConsoleRunner
{
    public class Strategies
    {
        private const string _connString = "server=.\\SQLExpress;database=NH_Eg;Trusted_Connection=True;";
        private StandardKernel _kernel;

        #region Initialization
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
        #endregion

        public void ex01_GetVsLoad()
        {
            /*
            var sessionFactory = initializeDatabase();

            var goodID = 1;
            var badID = 2;

            retrieveCustomer(sessionFactory, goodID, (id, s) => s.Get<Customer>(id));
            retrieveCustomer(sessionFactory, badID, (id, s) => s.Get<Customer>(id));
            retrieveCustomer(sessionFactory, goodID, (id, s) => s.Load<Customer>(id));
            retrieveCustomer(sessionFactory, badID, (id, s) => s.Load<Customer>(id));
             * */
        }

        public void ex02_getThenLoadSameObject()
        {
            /*
            var sessionFactory = initializeDatabase();

            wrap(sessionFactory, session =>
            {
                var c1 = session.Get<Customer>(1);
                var c2 = session.Load<Customer>(1);
                describe(c1);
                describe(c2);
            });
             * */

        }
        /*
        public void ex03_addGetVsLoad()
        {
            var sessionFactory = initializeDatabase();

            wrap(sessionFactory, session =>
            {
                var c = session.Get<Customer>(1);
                var o = new Order() {Customer = c, OrderDate = DateTime.Now};
                session.Save(o);
            });
            wrap(sessionFactory, session =>
            {
                var c = session.Load<Customer>(1);
                var o = new Order() { Customer = c, OrderDate = DateTime.Now };
                session.Save(o);
            });
        }
        */
        public void ex04_LINQ()
        {
            /*
            var sessionFactory = initializeDatabase();

            wrap(sessionFactory, session =>
            {
                var customers = session.Query<Customer>().Where(c => c.FirstName.StartsWith("M")).ToList();
                describe(customers);
            });

            wrap(sessionFactory, session =>
            {
                var customers = session.Query<Customer>().Where(c => c.Orders.Count() > 3).ToList();
                describe(customers, "customers with more than 3 orders");
            });

            wrap(sessionFactory, session =>
            {
                var query = from c in session.Query<Customer>()
                    where c.Orders.Count() > 3
                    orderby c.FirstName, c.LastName
                    let count = c.Orders.Count()
                    select new {c.FirstName, c.LastName, count};
                var results = query.ToList(); // avoid potential requery
                foreach (var stats in results)
                {
                    Trace.WriteLine(string.Format("{0} {1} placed {2} orders", stats.FirstName, stats.LastName, stats.count));
                }
            });

            wrap(sessionFactory, session =>
            {
                var query = from c in session.Query<Customer>()
                            where c.Orders.Count() > 2
                            orderby c.FirstName, c.LastName
                            let count = c.Orders.Count()
                            select new { c.FirstName, c.LastName, count };
                var augmented = from stat in query
                    where stat.FirstName.StartsWith("M")
                    select stat;
                var results = augmented.ToList(); // avoid potential requery
                foreach (var stats in results)
                {
                    Trace.WriteLine(string.Format("{0} {1} placed {2} orders", stats.FirstName, stats.LastName, stats.count));
                }
            });
             * */
        }

        public void ex05_HQL()
        {
            /*
            var sessionFactory = initializeDatabase();

            wrap(sessionFactory, session =>
            {
                var query = session.CreateQuery("select c from Customer c " +
                                                "where c.FirstName Like 'T%'");
                IList<Customer> customers = query.List<Customer>();
                describe(customers, "Customers with first name starting with T");
            });

            wrap(sessionFactory, session =>
            {
                var query = session.CreateQuery("select c from Customer c " +
                                                //"where size(c.Orders) > 3");
                                                "where c.Orders.size > 3");
                describe(query.List<Customer>(), "Customers with more than 3 orders");
            });

            wrap(sessionFactory, session =>
            {
                var query = session.CreateQuery("select c from Customer c " +
                                                "where c.Orders.size <= 3" +
                                                "order by c.FirstName desc");
                describe(query.List<Customer>(), "Customers with more than <= 3 orders sorted");
            });
             * */
        }

        public void ex06_CriteriaQuery()
        {
            /*
            var sessionFactory = initializeDatabase();

            wrap(sessionFactory, session =>
            {
                var query = session.CreateCriteria<Customer>()
                    .Add(Restrictions.Like("FirstName", "B%"));
                describe(query.List<Customer>(), "Customers with first name starting with B");
            });

            wrap(sessionFactory, session =>
            {
                var query = session.CreateCriteria<Customer>()
                    .Add(Restrictions.Eq("FirstName", "Mikael"));
                describe(query.List<Customer>(), "Customers with first name Mikael");
            });
             * */
        }

        #region private methods
        private void wrap(ISessionFactory sessionFactory, Action<ISession> action)
        {
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                action(session);
                tx.Commit();
            }
        }

        private void retrieveCustomer(ISessionFactory sessionFactory, int id, Func<int, ISession, Customer> retriever)
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                using (var tx = session.BeginTransaction())
                {
                    var customer = retriever(id, session);
                    Trace.WriteLine("And the result is...");
                    describe(customer);
                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Exception...");
                Trace.WriteLine(ex.Message);
                if (ex.InnerException != null) Trace.WriteLine(ex.InnerException.Message);
            }
        }

        /*
        using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                tx.Commit();
            }
         * */

        private void describe(object o, string msg = null)
        {
            if (msg != null) Trace.WriteLine(msg);
            if (o == null) Trace.WriteLine("... (null)");
            if (o is INHibernateProxy) Trace.Write("Proxy: ");
            Trace.WriteLine(o);
        }

        private void describe(IList<Customer> customers, string msg = null)
        {
            if (msg != null) Trace.WriteLine(msg);
            foreach (var customer in customers) describe(customer);
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

        private ISessionFactory initializeDatabase(int numCustomers = 5)
        {
            createDatabaseFluently();
            var customer = createNewCustomersWithOrders(numCustomers);
            var session = insertAndReturnFactory(customer);
            Trace.WriteLine("Done initialization...\n");
            return session;
        }

        private ISessionFactory insertAndReturnFactory(List<Customer> customers)
        {
            var sessionFactory = _kernel.Get<ISessionFactory>("sessionFactory");
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                foreach (var customer in customers)
                {
                    Trace.WriteLine("New customer:");
                    Trace.WriteLine(customer);

                    session.Save(customer);
                }

                tx.Commit();

                Trace.WriteLine("After save:");
                foreach (var c in customers) Trace.WriteLine(c);
            }

            return sessionFactory;
        }

        private List<Customer> createNewCustomersWithOrders(int numCustomers = 1)
        {
            var customers = new List<Customer>();
            var names = new[] {"Mike", "Marcia", "Mikael", "Bleu", "Tagg"};
            var max = Math.Min(5, numCustomers);
            for (var i = 0; i < max; i++)
            {
                customers.Add(createNewCustomerWithOrders(names[i], max - i));
            }
            return customers;
        }

        private Customer createNewCustomerWithOrders(string name = "Mike", int numOrders = 0)
        {
            var c = new Customer()
            {
                FirstName = name,
                LastName = "Heydt",
                HasGoldStatus = true,
                MemberSince = new DateTime(2012, 1, 1),
                CreditRating = CustomerCreditRating.Good,
                ShippingAddress = new ShippingAddress()
                {
                    City = "Missoula",
                    State = "MT",
                },
                Orders = Enumerable.Range(0, numOrders).Select(i => new Order()
                {
                    OrderDate = DateTime.Now.AddDays(-i)
                })
            };
            return c;
        }

        #endregion
    }
}
