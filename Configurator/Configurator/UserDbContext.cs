﻿using Configurator.Models.Components;
using Microsoft.EntityFrameworkCore;
using Configurator.Models.UserModels;
using Configurator.Models.PCBuider;
using Microsoft.Extensions.Configuration;

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
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string? connectionString = configuration["ConnectionStrings:Users"];
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(a => a.UserId);
            modelBuilder.Entity<User>()
                .Property(p => p.UserRole)
                .HasConversion<string>();

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
