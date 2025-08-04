using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data {
    public class MyAppDbContext : DbContext {
        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }

        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options){
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 4, Name = "Sample Item", Price = 9.99, SerialNumberId = 5 }
            );
            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { Id = 5, Number = "SN12345", ItemId = 4 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
