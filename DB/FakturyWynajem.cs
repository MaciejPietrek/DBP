//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class FakturyWynajem
    {
        public int id_faktury { get; set; }
        public Nullable<int> id_wynajem { get; set; }
        public float cena { get; set; }
        public int numer_faktury { get; set; }
        public Nullable<System.DateTime> data_platnosci { get; set; }
    
        public virtual Wynajmy Wynajmy { get; set; }
    }
}
