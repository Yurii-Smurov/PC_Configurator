using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Models.Components;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Runtime.Intrinsics.Arm;

namespace Configurator
{
    class PCComponentDbContext : DbContext
    {
        public PCComponentDbContext()
        {
            if (Database.EnsureCreated()) Database.Migrate(); //Если базы данных не существует - создает миграцию
        }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<GraphicsCard> GraphicsCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Database=TestDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Processor>()
                .ToTable("Processors")
                .HasKey(a => a.Id);
            modelBuilder.Entity<Processor>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<GraphicsCard>()
                .ToTable("GraphicCards")
                .HasKey(a => a.Id);
            modelBuilder.Entity<GraphicsCard>()
                .Property(p => p.Type)
                .HasConversion<string>();
        }
    }
}
