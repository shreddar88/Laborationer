//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GruppAsc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Bestallningar
    {
        public Bestallningar()
        {
            this.Fakturors = new HashSet<Fakturor>();
        }
         [DisplayName("Beställnings ID")]
        public int BID { get; set; }
        public int KID { get; set; }
        public System.DateTime Datum { get; set; }
         [DisplayName("Arbetsperiod")]
        public System.DateTime ArbetsPeriod { get; set; }
    
        public virtual ICollection<Fakturor> Fakturors { get; set; }
        public virtual KundInfo KundInfo { get; set; }
    }
}
