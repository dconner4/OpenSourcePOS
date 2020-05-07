using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.Interfaces
{
    public interface  IItem
    {

        /// <summary>
        /// The id of the record
        /// </summary>
        [Key]
        long Id { get; set; }

        /// <summary>
        /// The sku number of the item.
        /// </summary>
        /// <example>
        /// "12345", "1234-5", "1-2345" etc
        /// </example>
        [Required]
        [MaxLength(ErrorMessage = "Sku is to long. Must be no more than 128 characters")]
        string Sku { get; set; }

        /// <summary>
        /// A short description of the item.
        /// </summary>
        /// <example>
        /// Apples, Toilet Paper, Chicken Thighs
        /// </example>
        [Required]
        [MaxLength(ErrorMessage = "Title is to long. Must be no more than 128 characters")]
        string Title { get; set; }

        /// <summary>
        /// A long description of the item
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// The base price of the item.
        /// </summary>
        [Required]
        double Price { get; set; }

        /// <summary>
        /// The cost of the item from the vendor.
        /// </summary>
        [Required]
        double Cost { get; set; }

        /// <summary>
        /// The quantity of items being sold.
        /// </summary>
        [Required]
        [DefaultValue(0)]
        int Quantity { get; set; }
    }
}
