using Models;
using System.Collections.Generic;

namespace ViewModels.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISalesViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        List<SaleItem> ItemList { get; set; }
    }
}
