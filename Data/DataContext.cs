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

    }
}
