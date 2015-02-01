using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using St.Eg.NHibernate.Fundies.ConsoleRunner.Domain;

namespace St.Eg.NHibernate.Fundies.ConsoleRunner.Mappings
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table("Customers");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Phone);
            Map(x => x.CompanyName);
            Map(x => x.EmailAddress);
            Map(x => x.Title);
        }
    }
}
