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
    
    public partial class INVOICE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INVOICE()
        {
            this.DETAIL_INVOICE = new HashSet<DETAIL_INVOICE>();
            this.CHANGE_OR_REFUND_PRODUCT = new HashSet<CHANGE_OR_REFUND_PRODUCT>();
            this.RECEIVE_WARRANTY = new HashSet<RECEIVE_WARRANTY>();
        }
    
        public int ID { get; set; }
        public string NAME_ID { get; set; }
        public int ID_CUSTOMER { get; set; }
        public Nullable<int> ID_STAFF { get; set; }
        public Nullable<int> ID_STORE { get; set; }
        public double TOTAL { get; set; }
        public Nullable<System.DateTime> INVOICE_DATE { get; set; }
        public Nullable<double> VAT { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETAIL_INVOICE> DETAIL_INVOICE { get; set; }
        public virtual STAFF STAFF { get; set; }
        public virtual STORE STORE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHANGE_OR_REFUND_PRODUCT> CHANGE_OR_REFUND_PRODUCT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RECEIVE_WARRANTY> RECEIVE_WARRANTY { get; set; }
    }
}
