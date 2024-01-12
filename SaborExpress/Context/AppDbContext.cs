using Microsoft.EntityFrameworkCore;
using SaborExpress.Models;

namespace SaborExpress.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Snack> Snacks { get; set; }    
        public DbSet<CartPurchaseItem> CartPurchaseItems { get; set; }
    }
}
