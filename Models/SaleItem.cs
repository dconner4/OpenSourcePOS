namespace Models
{
    /// <summary>
    /// Sales Item for the SalesView.
    /// </summary>
    public class SaleItem
    {
        /// <summary>
        /// The sku number of the item.
        /// </summary>
        /// <example>
        /// "12345", "1234-5", "1-2345" etc
        /// </example>
        public string Sku { get; set; }

        /// <summary>
        /// A short description of the item.
        /// </summary>
        /// <example>
        /// Apples, Toilet Paper, Chicken Thighs
        /// </example>
        public string ShortDescription { get; set; }

        /// <summary>
        /// The quantity of items being sold.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The base price of the item.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// The price of the item mulitplied by the quantity being sold.
        /// </summary>
        public double TotalPrice => Quantity * Price;
    }
}
