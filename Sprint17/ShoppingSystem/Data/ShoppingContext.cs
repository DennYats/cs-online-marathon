using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Models;

namespace ShoppingSystem.Data
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options): base(options){}

        public ShoppingContext() { }
        
        public DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public DbSet<Supermarket> Supermarkets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrdersDetails { get; set; }
    }
}