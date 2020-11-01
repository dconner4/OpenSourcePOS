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
        private int _tempQty;

        /// <inheritdoc cref="IItem"/>
        public long Id { get; set; }

        /// <inheritdoc cref="IItem"/>
        public string Sku { get; set; }

        /// <inheritdoc cref="IItem"/>
        public string Title { get; set; }

        /// <inheritdoc cref="IItem"/>
        public string Description { get; set; }

        /// <inheritdoc cref="IItem"/>
        public double Cost { get; set; }

        /// <inheritdoc cref="IItem"/>
        public double Price { get; set; }

        /// <inheritdoc cref="IItem"/>
        public int Quantity { get; set; }

        /// <summary>
        /// The temporary quantity selected
        /// </summary>
        [NotMapped]
        public int TempQty
        {
            get => _tempQty;
            set
            {
                if (value > Quantity)
                {
                    Quantity -= Quantity;
                    _tempQty = Quantity;
                    return;
                }

                _tempQty = value;
            }
        }
        /// <summary>
        /// Indicates whether or not the record passed validation and can be saved
        /// </summary>
        [NotMapped]
        public bool PassesValidation => !string.IsNullOrWhiteSpace(Sku);
    }
}
