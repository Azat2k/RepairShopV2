using Microsoft.EntityFrameworkCore;
using RepairShopV2.Models;
using System.Collections.Generic;

namespace RepairShopV2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SparePartStorage> SparePartStorages { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientCompany> ClientCompanies { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<ClientVehicle> ClientVehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.ClientCompany)
                .WithMany(cc => cc.Clients)
                .HasForeignKey(c => c.ClientCompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ClientVehicle>()
                .HasOne(cv => cv.Client)
                .WithMany(c => c.ClientVehicles)
                .HasForeignKey(cv => cv.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<ClientVehicle>()
            //    .HasOne(cv => cv.ClientCompany)
            //    .WithMany(cc => cc.ClientVehicles)
            //    .HasForeignKey(cv => cv.ClientCompanyId)
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ClientVehicle>()
                .HasOne(cv => cv.VehicleMake)
                .WithMany(vm => vm.ClientVehicles)
                .HasForeignKey(cv => cv.VehicleMakeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ClientVehicle>()
                .HasOne(cv => cv.VehicleModel)
                .WithMany(vm => vm.ClientVehicles)
                .HasForeignKey(cv => cv.VehicleModelId)
                .OnDelete(DeleteBehavior.NoAction);
        }
        public DbSet<RepairShopV2.Models.Order> Order { get; set; } = default!;

    }
}
