﻿using Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    /// <summary>
    /// Inventory Item for the InventoryView
    /// </summary>
    public class InventoryItem : IItem
    {
        [Key]
        /// <inheritdoc cref="IItem"/>
        public string Sku { get; set; }

        /// <inheritdoc cref="IItem"/>
        public string Title { get; set; }

        /// <inheritdoc cref="IItem"/>
        public string Description { get; set; }

        /// <summary>
        /// The cost of the item from the vendor.
        /// </summary>
        public double Cost { get; set; }

        /// <inheritdoc cref="IItem"/>
        public double Price { get; set; }

        /// <inheritdoc cref="IItem"/>
        public int Quantity { get; set; }
    }
}