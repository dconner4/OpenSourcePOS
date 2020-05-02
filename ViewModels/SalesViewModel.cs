using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Models;
using ViewModels.Interfaces;

namespace ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class SalesViewModel
    {
        public SalesViewModel()
        {
            int x = 0;
            ItemList = new ObservableCollection<SaleItem>();
            ItemList.Add(new SaleItem
            {
                Sku = "1234",
                ShortDescription = "Apples",
                Quantity = 5,
                Price = 1.234
            });
            ItemList.Add(new SaleItem
            {
                Sku = "5678",
                ShortDescription = "Bananas",
                Quantity = 10,
                Price = 5.678
            });
        }
        
        public ObservableCollection<SaleItem> ItemList { get; set; }

        public int TotalQuantity => ItemList.Sum(x => x.Quantity);
    }
}
