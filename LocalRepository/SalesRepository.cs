using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalRepository.Context;
using LocalRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace LocalRepository
{
    public class SalesRepository : ISalesRepository
    {
        /// <inheritdoc cref="ISalesRepository"/>
        public IEnumerable<SaleItem> GetSaleItems()
        {
            using (var context = new LocalDatabaseContext())
            {
                context.SalesItems.Load();
                return context.SalesItems.ToList();
            }
        } 

        /// <inheritdoc cref="ISalesRepository"/>
        public async Task AddSalesItem(InventoryItem item)
        {
            if (item == null || CheckIfSaleItemExists(item.Sku)) return;

            using (var context = new LocalDatabaseContext())
            {
                await context.SalesItems.AddAsync(new SaleItem(item));
                await context.SaveChangesAsync();
            }
        }

        /// <inheritdoc cref="ISalesRepository"/>
        public async Task UpdateSaleQtyOnItem(string sku, int qty)
        {
            if (string.IsNullOrWhiteSpace(sku) || !CheckIfSaleItemExists(sku)) return;

            using (var context = new LocalDatabaseContext())
            {
                var saleItem = context.SalesItems.FirstOrDefault(x => x.Sku == sku);
                if (saleItem != null)
                {
                    saleItem.Quantity += qty;
                    await context.SaveChangesAsync();
                }
            }
        }

        /// <inheritdoc cref="ISalesRepository"/>
        public bool CheckIfSaleItemExists(string sku)
        {
            bool exists;
            using (var context = new LocalDatabaseContext())
            {
                exists = context.SalesItems.Any(x => x.Sku == sku);
            }

            return exists;
        }
    }
}
