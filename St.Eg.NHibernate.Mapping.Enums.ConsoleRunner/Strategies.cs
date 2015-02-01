using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Ninject;
using St.Eg.NHibernate.Domain;
using St.Eg.NHibernate.FluentMappings;

namespace St.Eg.NHibernate.Mapping.Enums.ConsoleRunner
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

        public void ex1_createCustomerWithEnum()
        {
            ex99_CreateDatabaseFluent();

            var sessionFactory = _kernel.Get<ISessionFactory>("sessionFactoryShowSql");
            using (var session = sessionFactory.OpenSession())
            {
                insertNewCustomers(session);
            }
        }

        private void insertNewCustomers(ISession session)
        {
            using (var tx = session.BeginTransaction())
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
                    }
                };
                session.Save(c);
                c = new Customer()
                {
                    FirstName = "Marcia",
                    LastName = "Heydt",
                    HasGoldStatus = true,
                    MemberSince = new DateTime(2012, 2, 2),
                    CreditRating = CustomerCreditRating.VeryGood,
                    ShippingAddress = new ShippingAddress()
                    {
                        City = "Missoula",
                        State = "MT",
                    }
                };
                session.Save(c);
                tx.Commit();
            }
        }


        public void ex99_CreateDatabaseFluent()
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
