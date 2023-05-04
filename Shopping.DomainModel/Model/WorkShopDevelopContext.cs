using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shopping.DomainModel.Model
{
    public class WorkShopDevelopContext:DbContext
    {
        public WorkShopDevelopContext(DbContextOptions<WorkShopDevelopContext> options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configuration.CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.ProductConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.ProductImageConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
