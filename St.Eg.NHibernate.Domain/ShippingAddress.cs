using System;
using System.Collections.Generic;

namespace St.Eg.NHibernate.Domain
{
    // used as a component
	public partial class ShippingAddress
	{
		public ShippingAddress()
		{		
		}

        public virtual int Id { get; set; }
        public virtual string City { get; set; }
	    public virtual string Country { get; set; }
	    public virtual string PostalCode { get; set; }
	    public virtual string State { get; set; }
	    public virtual string Street1 { get; set; }
	    public virtual string Street2 { get; set; }
	    /*
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as ShippingAddress);
		}
		
		public virtual bool Equals(ShippingAddress obj)
		{
			if (obj == null) return false;

			if (Equals(City, obj.City) == false) return false;
			if (Equals(Country, obj.Country) == false) return false;
			if (Equals(Id, obj.Id) == false) return false;
			if (Equals(PostalCode, obj.PostalCode) == false) return false;
			if (Equals(Region, obj.Region) == false) return false;
			if (Equals(Street1, obj.Street1) == false) return false;
			if (Equals(Street2, obj.Street2) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (City != null ? City.GetHashCode() : 0);
			result = (result * 397) ^ (Country != null ? Country.GetHashCode() : 0);
			result = (result * 397) ^ Id.GetHashCode();
			result = (result * 397) ^ (PostalCode != null ? PostalCode.GetHashCode() : 0);
			result = (result * 397) ^ (Region != null ? Region.GetHashCode() : 0);
			result = (result * 397) ^ (Street1 != null ? Street1.GetHashCode() : 0);
			result = (result * 397) ^ (Street2 != null ? Street2.GetHashCode() : 0);
			return result;
		}
         * */
	}
}