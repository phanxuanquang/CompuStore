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
    
    public partial class LINE_UP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LINE_UP()
        {
            this.COMMON_SPECS = new HashSet<COMMON_SPECS>();
        }
    
        public int ID { get; set; }
        public string NAME_ID { get; set; }
        public string NAME { get; set; }
        public string MANUFACTURER { get; set; }
        public string COUNTRY { get; set; }
        public Nullable<double> PROFIT_RATIO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMON_SPECS> COMMON_SPECS { get; set; }
    }
}