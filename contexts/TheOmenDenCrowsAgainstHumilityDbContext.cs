﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using TheOmenDen.CrowsAgainstHumility.Importer.contexts.Configurations;
using TheOmenDen.CrowsAgainstHumility.Importer.Models;
#nullable enable

namespace TheOmenDen.CrowsAgainstHumility.Importer.contexts
{
    public partial class TheOmenDenCrowsAgainstHumilityDbContext : DbContext
    {

        public TheOmenDenCrowsAgainstHumilityDbContext()
        {

        }

        public TheOmenDenCrowsAgainstHumilityDbContext(DbContextOptions<TheOmenDenCrowsAgainstHumilityDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlackCard> BlackCards { get; set; } = null!;
        public virtual DbSet<Pack> Packs { get; set; } = null!;
        public virtual DbSet<WhiteCard> WhiteCards { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=CrowsAgainstHumility.Db;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.BlackCardConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PackConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.WhiteCardConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
