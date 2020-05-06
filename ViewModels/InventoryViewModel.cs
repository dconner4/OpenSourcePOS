using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Services;
using LocalRepository.Interfaces;

namespace ViewModels
{
    public class InventoryViewModel : BindableBase
    {

        private readonly IInventoryRepository _inventoryRepository;

        public InventoryViewModel(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;

            InventoryList = new ObservableCollection<InventoryItem>(_inventoryRepository.GetInventoryItems());
            CurrentInventoryItem = InventoryList.FirstOrDefault();

            AddOrUpdateInventoryItem = new AsyncRelayCommand(AddOrUpdateInventoryItemCommand);
        }

        private void AddItem()
        {

        }

        public ObservableCollection<InventoryItem> InventoryList { get; set; }

        private InventoryItem _currentInventoryItem;

        public InventoryItem CurrentInventoryItem
        {
            get => _currentInventoryItem;
            set
            {
                _currentInventoryItem = value;
                OnPropertyChanged();
            }
        }

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
