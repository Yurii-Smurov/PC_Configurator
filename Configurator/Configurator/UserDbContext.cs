using Configurator.Models.Components;
using Microsoft.EntityFrameworkCore;
using Configurator.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator
{
    class UserDbContext : DbContext
    {
        public UserDbContext()
        {
            if (Database.EnsureCreated()) Database.Migrate(); //Если базы данных не существует - создает миграцию
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Database=users;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(a => a.Id);
        }
    }
}
