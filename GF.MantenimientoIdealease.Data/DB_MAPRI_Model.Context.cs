﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GF.MantenimientoIdealease.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_MAPRI_Entities : DbContext
    {
        public DB_MAPRI_Entities()
            : base("name=DB_MAPRI_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_Amnl> T_Amnl { get; set; }
        public virtual DbSet<T_Errr> T_Errr { get; set; }
        public virtual DbSet<T_Usrs> T_Usrs { get; set; }
        public virtual DbSet<TC_Abrn> TC_Abrn { get; set; }
        public virtual DbSet<TC_Acls> TC_Acls { get; set; }
        public virtual DbSet<TC_Actl> TC_Actl { get; set; }
        public virtual DbSet<TC_Anpc> TC_Anpc { get; set; }
        public virtual DbSet<TC_Edsc> TC_Edsc { get; set; }
        public virtual DbSet<TC_Etyp> TC_Etyp { get; set; }
        public virtual DbSet<TC_Intr> TC_Intr { get; set; }
        public virtual DbSet<TC_Ucst> TC_Ucst { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<T_Ampr> T_Ampr { get; set; }
        public virtual DbSet<T_Ihmn> T_Ihmn { get; set; }
        public virtual DbSet<TC_Amcn> TC_Amcn { get; set; }
    }
}
