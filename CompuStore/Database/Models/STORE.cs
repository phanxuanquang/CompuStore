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
    
    public partial class STORE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STORE()
        {
            this.IMPORT_WAREHOUSE = new HashSet<IMPORT_WAREHOUSE>();
            this.INVOICEs = new HashSet<INVOICE>();
        }
    
        public int ID { get; set; }
        public string NAME_ID { get; set; }
        public Nullable<int> ID_STAFF_MANAGER { get; set; }
        public string NAME { get; set; }
        public string ADDRESS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IMPORT_WAREHOUSE> IMPORT_WAREHOUSE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICE> INVOICEs { get; set; }
        public virtual STAFF STAFF { get; set; }
    }
}