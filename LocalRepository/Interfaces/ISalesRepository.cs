using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace LocalRepository.Interfaces
{
    public interface ISalesRepository
    {
        /// <summary>
        /// Gets the set of <see cref="SaleItem"/> from the database
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="SaleItem"/>s</returns>
        IEnumerable<SaleItem> GetSaleItems();

        /// <summary>
        /// Adds a new <see cref="SaleItem"/> to the database if one doesn't already exist
        /// </summary>
        /// <param name="item">The <see cref="InventoryItem"/> to add to the sale</param>
        Task AddSalesItem(InventoryItem item);

        /// <summary>
        /// Update the <see cref="SaleItem"/> associated with this <see cref="InventoryItem"/>
        /// </summary>
        /// <param name="sku">The sku of the item to update</param>
        /// <param name="qty">The quantity to add to the item</param>
        Task UpdateSaleQtyOnItem(string sku, int qty);

        /// <summary>   
        /// Checks if there is a sales entry with the associated sku already
        /// </summary>
        /// <param name="sku">The sku to search</param>
        bool CheckIfSaleItemExists(string sku);
    }
}
