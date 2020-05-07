using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Models;

namespace ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class SalesViewModel
    {
        public SalesViewModel()
        {
            ItemList = new ObservableCollection<SaleItem>();
        }
        
        public ObservableCollection<SaleItem> ItemList { get; set; }

        public int TotalQuantity => ItemList.Sum(x => x.Quantity);
    }
}
