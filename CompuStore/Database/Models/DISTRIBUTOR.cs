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
    
    public partial class DISTRIBUTOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DISTRIBUTOR()
        {
            this.IMPORT_WAREHOUSE = new HashSet<IMPORT_WAREHOUSE>();
        }
    
        public int ID { get; set; }
        public string NAME_ID { get; set; }
        public string NAME { get; set; }
        public string ADDRESS { get; set; }
        public string PHONE_NUMBER { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IMPORT_WAREHOUSE> IMPORT_WAREHOUSE { get; set; }
    }
}