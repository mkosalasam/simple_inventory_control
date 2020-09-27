using InventoryControlClient.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlClient.Data
{
    public class InventoryDbContext: DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Stock> Stock { get; set; }
    }
}
