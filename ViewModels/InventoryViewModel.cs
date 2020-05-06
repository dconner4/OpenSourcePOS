using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Services;
using LocalRepository.Interfaces;

namespace ViewModels
{
    public class InventoryViewModel : BindableBase
    {

        // Dependency Injection
        private readonly IInventoryRepository _inventoryRepository;

        // Fields
        private InventoryItem _currentInventoryItem;

        public InventoryViewModel(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;

            InventoryList = new ObservableCollection<InventoryItem>(_inventoryRepository.GetInventoryItems());
            CurrentInventoryItem = InventoryList.FirstOrDefault();

            AddOrUpdateInventoryItemCommand = new AsyncRelayCommand(AddOrUpdateInventoryItem);
            AddItemCommand = new RelayCommand(AddItem);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<InventoryItem> InventoryList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public InventoryItem CurrentInventoryItem
        {
            get => _currentInventoryItem;
            set
            {
                _currentInventoryItem = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public RelayCommand AddItemCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AsyncRelayCommand AddOrUpdateInventoryItemCommand { get; set; }

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task AddOrUpdateInventoryItem()
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

        /// <summary>
        /// 
        /// </summary>
        private void AddItem()
        {

        }
        #endregion
    }
}
