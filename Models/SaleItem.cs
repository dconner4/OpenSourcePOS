using Models.Interfaces;

namespace Models
{
    /// <summary>
    /// Sales Item for the SalesView.
    /// </summary>
    public class SaleItem : IItem
    {
        public SaleItem() {}
        
        public SaleItem(InventoryItem item)
        {
            Sku = item.Sku;
            Title = item.Title;
            Description = item.Description;
            Price = item.Price;
            Cost = item.Cost;
        }

        /// <inheritdoc cref="IItem"/>
        public long Id { get; set; }

        /// <inheritdoc cref="IItem"/>
        public string Sku { get; set; }

        /// <inheritdoc cref="IItem"/>
        public string Title { get; set; }

        /// <inheritdoc cref="IItem"/>
        public string Description { get; set; }

        /// <inheritdoc cref="IItem"/>
        public int Quantity { get; set; }

        /// <inheritdoc cref="IItem"/>
        public double Price { get; set; }

        /// <inheritdoc cref="IItem"/>
        public double Cost { get; set; }

        /// <summary>
        /// The price of the item multiplied by the quantity being sold.
        /// </summary>
        public double TotalPrice => Quantity * Price;
    }
}
