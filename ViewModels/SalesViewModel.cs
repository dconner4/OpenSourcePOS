using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LocalRepository.Interfaces;
using Models;
using Services;
using Services.Navigation;

namespace ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class SalesViewModel : IPageViewModel
    {
        private readonly ISalesRepository _salesRepository;
        private readonly INavigator _navigator;

        public SalesViewModel(ISalesRepository salesRepository,
            INavigator navigator)
        {
            _salesRepository = salesRepository;
            _navigator = navigator;

            ItemList = new ObservableCollection<SaleItem>(_salesRepository.GetSaleItems());
            
            AddItemCommand = new RelayCommand(AddItem);
        }

        public string Name => nameof(SalesViewModel);

        public void OnNavigated()
        {
            ItemList = new ObservableCollection<SaleItem>(_salesRepository.GetSaleItems());

        }

        public ObservableCollection<SaleItem> ItemList { get; set; }

        public RelayCommand AddItemCommand { get; set; }

        public int TotalQuantity => ItemList.Sum(x => x.Quantity);

        private void AddItem()
        {
            _navigator.OnChangeViewModel($"{nameof(InventoryViewModel)}");
        }
    }
}
