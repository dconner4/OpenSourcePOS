namespace Models.Interfaces
{
    public interface  IItem
    {

        /// <summary>
        /// The sku number of the item.
        /// </summary>
        /// <example>
        /// "12345", "1234-5", "1-2345" etc
        /// </example>
        string Sku { get; set; }

        /// <summary>
        /// A short description of the item.
        /// </summary>
        /// <example>
        /// Apples, Toilet Paper, Chicken Thighs
        /// </example>
        string Title { get; set; }

        string Description { get; set; }

        /// <summary>
        /// The base price of the item.
        /// </summary>
        double Price { get; set; }
        
        /// <summary>
        /// The quantity of items being sold.
        /// </summary>
        int Quantity { get; set; }
    }
}
