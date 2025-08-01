using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data {
    public class MyAppDbContext : DbContext {
        public DbSet<Item> Items { get; set; }

        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options){
            
        }
    }
}
