using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(c => c.ClientID);
            modelBuilder.Entity<Menu>().HasKey(m => m.MenuID);
            modelBuilder.Entity<Order>().HasKey(o => o.OrderID);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany()
                .HasForeignKey(o => o.ClientID);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Menu)
                .WithMany()
                .HasForeignKey(o => o.MenuID);
        }
    }
}
