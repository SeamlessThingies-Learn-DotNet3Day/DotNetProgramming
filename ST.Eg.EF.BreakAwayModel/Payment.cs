//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ST.Eg.EF.BreakAwayModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int ReservationId { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
    
        public virtual Reservation Reservation { get; set; }
    }
}
