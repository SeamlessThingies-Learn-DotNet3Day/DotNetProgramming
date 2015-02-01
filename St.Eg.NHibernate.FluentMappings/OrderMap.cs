using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using St.Eg.NHibernate.Domain;

namespace St.Eg.NHibernate.FluentMappings
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.OrderId).GeneratedBy.Native();
            Map(x => x.OrderDate);
            Map(x => x.ShippedDate).Nullable();
            Map(x => x.OnlineOrder);
            Map(x => x.SalesOrderNumber);
            Map(x => x.PurchaseOrderNumber);
            Map(x => x.SubTotal);
            Map(x => x.Comment);
            Map(x => x.PromotionId);
            //Component(x => x.ShippedTo);
            
            // 1:1 back to the customer
            References(x => x.Customer, "CustomerId");
        }
    }
}
