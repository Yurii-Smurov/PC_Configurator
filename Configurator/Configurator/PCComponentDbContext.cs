﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Models.Components;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Configurator
{
    class PCComponentDbContext : DbContext
    {
        public PCComponentDbContext()
        {
            if (Database.EnsureCreated()) Database.Migrate(); //Если базы данных не существует - создает миграцию
        }
        public DbSet<Processor> Processors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Database=TestDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Processor>()
                .ToTable("Processors")
                .HasKey(a => a.Id);
        }
    }
}
