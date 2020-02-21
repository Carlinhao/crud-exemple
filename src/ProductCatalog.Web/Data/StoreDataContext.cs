using Microsoft.EntityFrameworkCore;
using ProductCatalog.Web.Maps;
using ProductCatalog.Web.Models;

namespace ProductCatalog.Web.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=productCatalog;User ID=SA;Password=dockerCarlos2019!");
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
        }      
    }
}