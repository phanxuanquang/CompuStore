﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CompuStoreDBEntities : DbContext
    {
        public CompuStoreDBEntities()
            : base("name=CompuStoreDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<COLOR> COLORs { get; set; }
        public virtual DbSet<COMMON_USER> COMMON_USER { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public virtual DbSet<CHANGE_OR_REFUND_PRODUCT> CHANGE_OR_REFUND_PRODUCT { get; set; }
        public virtual DbSet<DETAIL_IMPORT_WAREHOUSE> DETAIL_IMPORT_WAREHOUSE { get; set; }
        public virtual DbSet<DETAIL_INVOICE> DETAIL_INVOICE { get; set; }
        public virtual DbSet<DETAIL_SPECS> DETAIL_SPECS { get; set; }
        public virtual DbSet<DISTRIBUTOR> DISTRIBUTORs { get; set; }
        public virtual DbSet<IMPORT_WAREHOUSE> IMPORT_WAREHOUSE { get; set; }
        public virtual DbSet<INVOICE> INVOICEs { get; set; }
        public virtual DbSet<LINE_UP> LINE_UP { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }
        public virtual DbSet<RANK> RANKs { get; set; }
        public virtual DbSet<RECEIVE_WARRANTY> RECEIVE_WARRANTY { get; set; }
        public virtual DbSet<STAFF> STAFFs { get; set; }
        public virtual DbSet<STAFFROLE> STAFFROLEs { get; set; }
        public virtual DbSet<STORE> STOREs { get; set; }
        public virtual DbSet<USERROLE> USERROLEs { get; set; }
        public virtual DbSet<COMMON_SPECS> COMMON_SPECS { get; set; }
        public virtual DbSet<DISPLAY_SPECS> DISPLAY_SPECS { get; set; }
        public virtual DbSet<INFOR> INFORs { get; set; }
        public virtual DbSet<UNIQUE_SPECS> UNIQUE_SPECS { get; set; }
    }
}
