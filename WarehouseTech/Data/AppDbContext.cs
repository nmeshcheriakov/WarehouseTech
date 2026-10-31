using Microsoft.EntityFrameworkCore;
using WarehouseTech.Models;

namespace WarehouseTech.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EquipmentType> EquipmentTypes => Set<EquipmentType>();
        public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Equipment> Equipments => Set<Equipment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EquipmentType>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Manufacturer>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.EquipmentType)
                .WithMany()
                .HasForeignKey(e => e.EquipmentTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Manufacturer)
                .WithMany()
                .HasForeignKey(e => e.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Country)
                .WithMany()
                .HasForeignKey(e => e.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
