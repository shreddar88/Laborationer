﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AsciEntities : DbContext
    {
        public AsciEntities()
            : base("name=AsciEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bestallningar> Bestallningars { get; set; }
        public virtual DbSet<Fakturor> Fakturors { get; set; }
        public virtual DbSet<KundInfo> KundInfoes { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<vPresentation> vPresentations { get; set; }
    }
}
