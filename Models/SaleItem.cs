using Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    /// <summary>
    /// Sales Item for the SalesView.
    /// </summary>
    public class SaleItem : IItem
    {
        [Key]
        public long Id { get; set; }

        /// <inheritdoc cref="IItem"/>
        public string Sku { get; set; }

        [MaxLength(ErrorMessage = "Title is to long. Must be no more than 128 characters")]
        /// <inheritdoc cref="IItem"/>
        public string Title { get; set; }

        /// <inheritdoc cref="IItem"/>
        public string Description { get; set; }

        /// <inheritdoc cref="IItem"/>
        public int Quantity { get; set; }

        /// <inheritdoc cref="IItem"/>
        public double Price { get; set; }

        /// <summary>
        /// The price of the item mulitplied by the quantity being sold.
        /// </summary>
        public double TotalPrice => Quantity * Price;
    }
}
