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
        public DbSet<Service> SparePartStorages { get; set; }
        public DbSet<RepairShopV2.Models.SparePartStorage> SparePartStorage { get; set; } = default!;

    }
}
