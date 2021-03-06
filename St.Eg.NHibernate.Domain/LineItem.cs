using System;
using System.Collections.Generic;

namespace St.Eg.NHibernate.Domain
{
	public partial class LineItem
	{
		public LineItem()
		{		
		}

	    public virtual int LineItemId { get; set; }
	    public virtual int OrderQty { get; set; }
	    public virtual double? UnitPrice { get; set; }
	    public virtual double? UnitPriceDiscount { get; set; }
	    public virtual Order Order { get; set; }
	    public virtual Product Product { get; set; }
	    public virtual Shipment Shipment { get; set; }
	    /*
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as LineItem);
		}
		
		public virtual bool Equals(LineItem obj)
		{
			if (obj == null) return false;

			if (Equals(LineItemId, obj.LineItemId) == false) return false;
			if (Equals(OrderQty, obj.OrderQty) == false) return false;
			if (Equals(UnitPrice, obj.UnitPrice) == false) return false;
			if (Equals(UnitPriceDiscount, obj.UnitPriceDiscount) == false) return false;
			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ LineItemId.GetHashCode();
			result = (result * 397) ^ OrderQty.GetHashCode();
			result = (result * 397) ^ (UnitPrice != null ? UnitPrice.GetHashCode() : 0);
			result = (result * 397) ^ (UnitPriceDiscount != null ? UnitPriceDiscount.GetHashCode() : 0);
			return result;
		}
         * */
	}
}