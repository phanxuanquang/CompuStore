//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CompuStore.Database.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UNIQUE_SPECS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UNIQUE_SPECS()
        {
            this.DETAIL_SPECS = new HashSet<DETAIL_SPECS>();
        }
    
        public int UNIQUE_SPECS_NO { get; set; }
        public string ID { get; set; }
        public string ID_DISPLAY_SPECS { get; set; }
        public string CPU { get; set; }
        public string IGPU { get; set; }
        public string RAM { get; set; }
        public string TYPE_DRIVE { get; set; }
        public Nullable<int> SIZE_DRIVE { get; set; }
        public string GPU { get; set; }
        public Nullable<decimal> BATTERY_CAPACITY { get; set; }
        public Nullable<decimal> WEIGHT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETAIL_SPECS> DETAIL_SPECS { get; set; }
        public virtual DISPLAY_SPECS DISPLAY_SPECS { get; set; }
    }
}
