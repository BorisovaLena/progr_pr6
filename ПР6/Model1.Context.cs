﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ПР6
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Table_Genders> Table_Genders { get; set; }
        public virtual DbSet<Table_Pasporta> Table_Pasporta { get; set; }
        public virtual DbSet<Table_Pokupki> Table_Pokupki { get; set; }
        public virtual DbSet<Table_Postavki> Table_Postavki { get; set; }
        public virtual DbSet<Table_Providers> Table_Providers { get; set; }
        public virtual DbSet<Table_Roles> Table_Roles { get; set; }
        public virtual DbSet<Table_Sotrudniki> Table_Sotrudniki { get; set; }
        public virtual DbSet<Table_Tovari> Table_Tovari { get; set; }
    }
}
