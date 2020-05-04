using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Services;
using LocalRepository.Interfaces;

namespace ViewModels
{
    public class InventoryViewModel
    {

        private readonly IInventoryRepository _inventoryRepository;

        public InventoryViewModel(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;

            InventoryList = _inventoryRepository.GetInventoryItems();
            AddOrUpdateInventoryItem = new AsyncRelayCommand(AddOrUpdateInventoryItemCommand);
        }

        private void AddItem()
        {

        }

        public IEnumerable<InventoryItem> InventoryList { get; set; }

        public InventoryItem CurrentInventoryItem { get; set; }

        public RelayCommand AddItemCommand { get; set; }

        public AsyncRelayCommand AddOrUpdateInventoryItem { get; set; }

        private async Task AddOrUpdateInventoryItemCommand()
        {
            //Check if the item is in the database
            if (!_inventoryRepository.CheckInventoryItemExists(CurrentInventoryItem.Sku))
            {
                //Add item to the database
                await _inventoryRepository.AddInventoryItem(CurrentInventoryItem);
                return;
            }

            //Update item in the database
            await _inventoryRepository.UpdateInventoryItem(CurrentInventoryItem);
        }
    }
}
