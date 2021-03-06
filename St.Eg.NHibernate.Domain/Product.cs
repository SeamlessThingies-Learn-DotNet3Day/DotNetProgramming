using System;
using System.Collections.Generic;

namespace St.Eg.NHibernate.Domain
{
	public partial class Product
	{
		public Product()
		{
		}

	    public virtual int Color { get; set; }
	    public virtual DateTime? DiscontinuedDate { get; set; }
	    public virtual double ListPrice { get; set; }
	    public virtual string Name { get; set; }
	    public virtual byte[] Photo { get; set; }
	    public virtual int ProductId { get; set; }
	    public virtual string ProductNumber { get; set; }
	    public virtual DateTime? SellEndDate { get; set; }
	    public virtual DateTime SellStartDate { get; set; }
	    public virtual double? ShippingWeight { get; set; }
	    public virtual string Size { get; set; }
	    public virtual double StandardCost { get; set; }
	    public virtual Category Category { get; set; }
	    public virtual IEnumerable<LineItem> LineItems { get; set; }
	    public virtual Promotion Promotion { get; set; }

        /*
	    public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as Product);
		}
		
		public virtual bool Equals(Product obj)
		{
			if (obj == null) return false;

			if (Equals(Color, obj.Color) == false) return false;
			if (Equals(DiscontinuedDate, obj.DiscontinuedDate) == false) return false;
			if (Equals(ListPrice, obj.ListPrice) == false) return false;
			if (Equals(Name, obj.Name) == false) return false;
			if (Equals(Photo, obj.Photo) == false) return false;
			if (Equals(ProductId, obj.ProductId) == false) return false;
			if (Equals(ProductNumber, obj.ProductNumber) == false) return false;
			if (Equals(SellEndDate, obj.SellEndDate) == false) return false;
			if (Equals(SellStartDate, obj.SellStartDate) == false) return false;
			if (Equals(ShippingWeight, obj.ShippingWeight) == false) return false;
			if (Equals(Size, obj.Size) == false) return false;
			if (Equals(StandardCost, obj.StandardCost) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ Color.GetHashCode();
			result = (result * 397) ^ (DiscontinuedDate != null ? DiscontinuedDate.GetHashCode() : 0);
			result = (result * 397) ^ ListPrice.GetHashCode();
			result = (result * 397) ^ (Name != null ? Name.GetHashCode() : 0);
			result = (result * 397) ^ (Photo != null ? Photo.GetHashCode() : 0);
			result = (result * 397) ^ ProductId.GetHashCode();
			result = (result * 397) ^ (ProductNumber != null ? ProductNumber.GetHashCode() : 0);
			result = (result * 397) ^ (SellEndDate != null ? SellEndDate.GetHashCode() : 0);
			result = (result * 397) ^ SellStartDate.GetHashCode();
			result = (result * 397) ^ (ShippingWeight != null ? ShippingWeight.GetHashCode() : 0);
			result = (result * 397) ^ (Size != null ? Size.GetHashCode() : 0);
			result = (result * 397) ^ StandardCost.GetHashCode();
			return result;
		}
         * */
	}
}