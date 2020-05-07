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

        private readonly ISalesRepository _salesRepository;

        // Fields
        private InventoryItem _currentInventoryItem;

        public InventoryViewModel(IInventoryRepository inventoryRepository, 
            ISalesRepository salesRepository)
        {
            _inventoryRepository = inventoryRepository;
            _salesRepository = salesRepository;

            InventoryList = new ObservableCollection<InventoryItem>(_inventoryRepository.GetInventoryItems());
            CurrentInventoryItem = InventoryList.FirstOrDefault();

            AddOrUpdateInventoryItemCommand = new AsyncRelayCommand(AddOrUpdateInventoryItem);
            AddItemCommand = new AsyncRelayCommand(AddItem);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<InventoryItem> InventoryList { get; set; }

        /// <summary>
        /// The current selected inventory item
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
        public AsyncRelayCommand AddItemCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AsyncRelayCommand AddOrUpdateInventoryItemCommand { get; set; }

        #region Private Methods
        /// <summary>
        /// Adds or updates the <see cref="CurrentInventoryItem"/> in the database
        /// </summary>
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
        /// Adds or updates the current on going sale with the <see cref="CurrentInventoryItem"/>
        /// </summary>
        private async Task AddItem()
        {
            if (!_salesRepository.CheckIfSaleItemExists(CurrentInventoryItem.Sku))
            {
                await _salesRepository.AddSalesItem(CurrentInventoryItem);
                return;
            }

            await _salesRepository.UpdateSaleQtyOnItem(CurrentInventoryItem.Sku, 1);
        }
        #endregion
    }
}
