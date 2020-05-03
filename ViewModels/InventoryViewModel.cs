using System.Collections.Generic;
using Models;
using Services;

namespace ViewModels
{
    public class InventoryViewModel
    {

        public InventoryViewModel()
        {

        }

        private void AddItem()
        {

        }

        public List<InventoryItem> InventoryList { get; set; }

        public RelayCommand AddItemCommand { get; set; }
    }
}
