using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using NHibernate.Collection.Generic;
using NHibernate.Mapping;

namespace St.Eg.NHibernate.Domain
{
	public partial class Customer
	{
		public Customer()
		{
		    //Orders = new PersistentGenericBag<Order>();
		}

        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string Phone { get; set; }
        public virtual string SalesPersonId { get; set; }
        public virtual string Title { get; set; }
        public virtual CustomerCreditRating CreditRating { get; set; }
        public virtual bool HasGoldStatus { get; set; }
        public virtual DateTime MemberSince { get; set; }
        public virtual ShippingAddress ShippingAddress { get; set; }
        
        
        public virtual IEnumerable<Order> Orders { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} {1} {2} {3}", this.GetType().Name, Id, FirstName, LastName));
            if (Orders != null)
                Orders.ToList().ForEach(o =>
                {
                    sb.AppendLine(string.Format("   {0} {1} {2} {3}", o.GetType().Name, o.OrderId, o.OrderDate,
                        describeCust(o.Customer)));
                });
            return sb.ToString();
        }

	    private string describeCust(Customer c)
	    {
	        if (c == null) return "null";
	        return string.Format("{0} {1} {2}", c.Id, c.FirstName, c.LastName);
	    }


	    public virtual void addOrder(Order order)
	    {
	        var bag = Orders as PersistentGenericBag<Order>;
	        bag.Add(order);
	        order.Customer = this;
	    }
	    /*
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as Customer);
		}
		
		public virtual bool Equals(Customer obj)
		{
			if (obj == null) return false;

			if (Equals(CompanyName, obj.CompanyName) == false) return false;
			if (Equals(EmailAddress, obj.EmailAddress) == false) return false;
			if (Equals(FirstName, obj.FirstName) == false) return false;
			if (Equals(Id, obj.Id) == false) return false;
			if (Equals(LastName, obj.LastName) == false) return false;
			if (Equals(Phone, obj.Phone) == false) return false;
			if (Equals(SalesPersonId, obj.SalesPersonId) == false) return false;
			if (Equals(Title, obj.Title) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (CompanyName != null ? CompanyName.GetHashCode() : 0);
			result = (result * 397) ^ (EmailAddress != null ? EmailAddress.GetHashCode() : 0);
			result = (result * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
			result = (result * 397) ^ Id.GetHashCode();
			result = (result * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
			result = (result * 397) ^ (Phone != null ? Phone.GetHashCode() : 0);
			result = (result * 397) ^ (SalesPersonId != null ? SalesPersonId.GetHashCode() : 0);
			result = (result * 397) ^ (Title != null ? Title.GetHashCode() : 0);
			return result;
		}
         * */
	}
}