using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace LocalRepository.Interfaces
{
    public interface IInventoryRepository
    {
        /// <summary>
        /// Gets the <see cref="InventoryItem"/> data set from the DataContext
        /// </summary>
        /// <returns>The <see cref="InventoryItem"/> data set</returns>
        IEnumerable<InventoryItem> GetInventoryItems();
        /// <summary>
        /// Adds a new <see cref="InventoryItem"/> to the database
        /// </summary>
        /// <param name="item">The <see cref="InventoryItem"/> to save to the database</param>
        Task AddInventoryItem(InventoryItem item);

        /// <summary>
        /// Update the item in the database with the <see cref="InventoryItem"/>
        /// </summary>
        /// <param name="item">The <see cref="InventoryItem"/> to update in the database</param>
        Task UpdateInventoryItem(InventoryItem item);

        /// <summary>
        /// Checks if the <see cref="InventoryItem"/> exists in the database
        /// </summary>
        /// <param name="sku">The <see cref="InventoryItem"/> to check for</param>
        /// <returns>A boolean indicating if the <see cref="InventoryItem"/> exists in the database</returns>
        bool CheckInventoryItemExists(string sku);
    }
}
