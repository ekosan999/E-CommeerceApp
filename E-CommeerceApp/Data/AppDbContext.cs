using E_CommeerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommeerceApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base (dbContextOptions)
        {
          
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Product");
            modelBuilder.HasSequence<int>("ProductID");
            modelBuilder.HasSequence<int>("OrderID");

            modelBuilder.Entity<Products>()
                .Property(o => o.ProductID)
                .HasDefaultValueSql("NEXT VALUE FOR Product.ProductID");

            modelBuilder.Entity<Orders>()
            .Property(o => o.OrdereID)
            .HasDefaultValueSql("NEXT VALUE FOR Product.OrderID");

            modelBuilder.Entity<Products>(x =>
            {
                x.Property(b => b.Name).IsRequired();
                x.Property(b => b.Price).IsRequired();
                x.Property(b => b.StockQuantity).IsRequired();
            });  
            modelBuilder.Entity<Orders>(x =>
            {
                x.Property(b => b.CustomerName).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
    
}
