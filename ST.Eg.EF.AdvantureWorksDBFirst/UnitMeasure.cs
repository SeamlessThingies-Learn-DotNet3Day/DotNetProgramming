//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ST.Eg.EF.AdvantureWorksDBFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class UnitMeasure
    {
        public UnitMeasure()
        {
            this.BillOfMaterials = new HashSet<BillOfMaterial>();
            this.Products = new HashSet<Product>();
            this.Products1 = new HashSet<Product>();
            this.ProductVendors = new HashSet<ProductVendor>();
        }
    
        public string UnitMeasureCode { get; set; }
        public string Name { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual ICollection<BillOfMaterial> BillOfMaterials { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Product> Products1 { get; set; }
        public virtual ICollection<ProductVendor> ProductVendors { get; set; }
    }
}
