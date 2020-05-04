using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalRepository.Context;
using LocalRepository.Interfaces;
using Models;

namespace LocalRepository
{
    public class InventoryRepository : IInventoryRepository
    {
        public IEnumerable<InventoryItem> GetInventoryItems()
        {
            using (var context = new LocalDatabaseContext())
            {
                return context.InventoryItems;
            }
        }
        /// <inheritdoc cref="IInventoryRepository"/>
        public async Task AddInventoryItem(InventoryItem item)
        {
            if (item == null && CheckInventoryItemExists(item.Sku)) return;

            using (var context = new LocalDatabaseContext())
            {
                await context.InventoryItems.AddAsync(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateInventoryItem(InventoryItem item)
        {
            if (item == null && !CheckInventoryItemExists(item.Sku)) return;

            using (var context = new LocalDatabaseContext())
            {
                context.InventoryItems.Update(item);
                await context.SaveChangesAsync();
            }
            
        }

        /// <inheritdoc cref="IInventoryRepository"/>
        public bool CheckInventoryItemExists(string sku)
        {
            bool exists = false;
            using (var context = new LocalDatabaseContext())
            {
                exists = context.InventoryItems.Any(x => x.Sku == sku);
            }

            return exists;
        }
    }
}
