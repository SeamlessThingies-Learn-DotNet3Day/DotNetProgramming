using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using St.Eg.NHibernate.Domain;

namespace St.Eg.NHibernate.FluentMappings
{
    public class ShippingAddressComponentMap : ComponentMap<ShippingAddress>
    {
        public ShippingAddressComponentMap()
        {
            Map(x => x.City);
            Map(x => x.Country);
            Map(x => x.PostalCode);
            Map(x => x.State);
            Map(x => x.Street1);
            Map(x => x.Street2);
        }
    }
}
