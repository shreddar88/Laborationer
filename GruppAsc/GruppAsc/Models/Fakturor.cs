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
    
    public partial class Fakturor
    {
        public int FID { get; set; }
        [DisplayName("Beställnings ID")]
        public int BID { get; set; }
        public System.DateTime Datum { get; set; }
        [DisplayName("Totalbelopp")]
        public decimal SubTotal { get; set; }
        public int StatusID { get; set; }
        [DisplayName("Arbetstimmar")]
        public int ArbetsTimmar { get; set; }
        [DisplayName("OCR-Nummer")]
        public int OCRNummer { get; set; }
    
        public virtual Bestallningar Bestallningar { get; set; }
        public virtual Status Status { get; set; }
    }
}
