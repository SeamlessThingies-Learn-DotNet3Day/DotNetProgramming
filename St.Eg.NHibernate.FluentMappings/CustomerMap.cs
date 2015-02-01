using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using St.Eg.NHibernate.Domain;
using FluentNHibernate.Mapping;

namespace St.Eg.NHibernate.FluentMappings
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Phone);
            Map(x => x.CompanyName);
            Map(x => x.EmailAddress);
            Map(x => x.Title);
            Map(x => x.CreditRating);
            Map(x => x.MemberSince);

            //Component(c => c.ShippingAddress);

            // 1:m with orders
            HasMany(x => x.Orders)
                .Cascade.AllDeleteOrphan()
                //.Inverse()
                //.Fetch.Select()
                //.Fetch.Join()
                .Table("Order")
                .KeyColumn("CustomerId");
        }
    }
}
