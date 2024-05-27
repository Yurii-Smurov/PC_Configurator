using Configurator.Models.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

        public DbSet<Motherboard> Motherboards { get; set; }

        public DbSet<Memory> Memory { get; set; }

        public DbSet<AirCoolingSystem> AirCoolingSystems { get; set; }

        public DbSet<LiquidCoolingSystem> LiquidCoolingSystems { get; set; }

        public DbSet<PowerUnit> PowerUnits { get; set; }

        public DbSet<HDD> HDD { get; set; }

        public DbSet<SSD> SSD { get; set; }

        public DbSet<ComputerCase> ComputerCases { get; set; }

        public DbSet<SoundCard> SoundCards { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string? connectionString = configuration["ConnectionStrings:PCComponents"];
            optionsBuilder.UseSqlServer(connectionString);
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

            modelBuilder.Entity<Motherboard>()
                .ToTable("Motherboards")
                .HasKey(a => a.Id);
            modelBuilder.Entity<Motherboard>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Memory>()
                .ToTable("Memory")
                .HasKey(a => a.Id);
            modelBuilder.Entity<Memory>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<AirCoolingSystem>()
                .ToTable("AirCoolingSystems")
                .HasKey(a => a.Id);
            modelBuilder.Entity<AirCoolingSystem>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<LiquidCoolingSystem>()
                .ToTable("LiquidCoolingSystems")
                .HasKey(a => a.Id);
            modelBuilder.Entity<LiquidCoolingSystem>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<PowerUnit>()
                .ToTable("PowerUnits")
                .HasKey(a => a.Id);
            modelBuilder.Entity<PowerUnit>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<HDD>()
                .ToTable("HDD")
                .HasKey(a => a.Id);
            modelBuilder.Entity<HDD>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<SSD>()
                .ToTable("SSD")
                .HasKey(a => a.Id);
            modelBuilder.Entity<SSD>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<ComputerCase>()
                .ToTable("ComputerCases")
                .HasKey(a => a.Id);
            modelBuilder.Entity<ComputerCase>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<SoundCard>()
                .ToTable("SoundCards")
                .HasKey(a => a.Id);
            modelBuilder.Entity<SoundCard>()
                .Property(p => p.Type)
                .HasConversion<string>();
        }
    }
}
