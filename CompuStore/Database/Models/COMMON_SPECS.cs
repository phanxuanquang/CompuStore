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
    
    public partial class COMMON_SPECS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COMMON_SPECS()
        {
            this.DETAIL_SPECS = new HashSet<DETAIL_SPECS>();
        }
    
        public int ID { get; set; }
        public string NAME_ID { get; set; }
        public int ID_LINE_UP { get; set; }
        public string NAME { get; set; }
        public Nullable<int> QUANTITY { get; set; }
        public Nullable<System.DateTime> RELEASED_YEAR { get; set; }
        public string CASE_MATERIAL { get; set; }
        public string PORT { get; set; }
        public string WEBCAM { get; set; }
        public string DIMENSIONS { get; set; }
        public string WIFI { get; set; }
        public string BLUETOOTH { get; set; }
    
        public virtual LINE_UP LINE_UP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETAIL_SPECS> DETAIL_SPECS { get; set; }
    }
}
