using Microsoft.EntityFrameworkCore;

namespace Inventory.Models
{
    public class InventoryContext: DbContext
    {
        public InventoryContext()
        {
        }
        public InventoryContext(DbContextOptions options) : base(options) { }
        public DbSet<InventoryModel> Inventorys { get; set; }
    }
}
