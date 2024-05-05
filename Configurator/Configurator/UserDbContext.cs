using Configurator.Models.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Models.UserModels;
using Microsoft.Identity.Client.Extensions.Msal;
using System.Runtime.Intrinsics.Arm;
using Configurator.Models.PCBuider;

namespace Configurator
{
    class UserDbContext : DbContext
    {
        public UserDbContext()
        {
            if (Database.EnsureCreated()) Database.Migrate(); //Если базы данных не существует - создает миграцию
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PC> PCs { get; set; }
        public DbSet<PCComponent> PCComponents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Database=Users;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(a => a.UserId);

            modelBuilder.Entity<PC>()
                .ToTable("PCs")
                .HasKey(a => a.PCId);

            modelBuilder.Entity<PCComponent>()
                .ToTable("PCComponents");

            modelBuilder.Entity<Processor>()
                .HasBaseType<PCComponent>();

            modelBuilder.Entity<GraphicsCard>()
                .HasBaseType<PCComponent>();

            modelBuilder.Entity<Motherboard>()
                .HasBaseType<PCComponent>();

            modelBuilder.Entity<Memory>()
                .HasBaseType<PCComponent>();

            modelBuilder.Entity<SSD>()
                .HasBaseType<PCComponent>();

            modelBuilder.Entity<HDD>()
                .HasBaseType<PCComponent>();

            modelBuilder.Entity<PowerUnit>()
                .HasBaseType<PCComponent>();

            modelBuilder.Entity<ComputerCase>()
                .HasBaseType<PCComponent>();

        }
    }
}
