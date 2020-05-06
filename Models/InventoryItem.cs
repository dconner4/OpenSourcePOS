using Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    /// <summary>
    /// Inventory Item for the InventoryView
    /// </summary>
    public class InventoryItem : IItem
    {

        /// <inheritdoc cref="IItem"/>
        [Key]
        public long Id { get; set; }

        /// <inheritdoc cref="IItem"/>
        [Required]
        public string Sku { get; set; }

        /// <inheritdoc cref="IItem"/>
        [Required]
        [MaxLength(125, ErrorMessage = "Title is too long, please shorten it to less than 125 characters")]
        public string Title { get; set; }

        /// <inheritdoc cref="IItem"/>
        public string Description { get; set; }

        /// <summary>
        /// The cost of the item from the vendor.
        /// </summary>
        [Required]
        public double Cost { get; set; }

        /// <inheritdoc cref="IItem"/>
        [Required]
        public double Price { get; set; }

        /// <inheritdoc cref="IItem"/>
        public int Quantity { get; set; }

        /// <summary>
        /// Indicates whether or not the record passed validation and can be saved
        /// </summary>
        [NotMapped]
        public bool PassesValidation => !string.IsNullOrWhiteSpace(Sku);
    }
}
