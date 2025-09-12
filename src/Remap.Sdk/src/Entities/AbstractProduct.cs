using System;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an abstract product.
    /// </summary>
    public abstract class AbstractProduct : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is archived.
        /// </summary>
        public bool? Archived { get; set; }

        /// <summary>
        /// Gets or sets the barcodes.
        /// </summary>
        public Barcode[] Barcodes { get; set; }

        /// <summary>
        /// Gets or sets the buy price.
        /// </summary>
        public Price BuyPrice { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the discount prohibited.
        /// </summary>
        public bool? DiscountProhibited { get; set; }

        /// <summary>
        /// Gets or sets the external code.
        /// </summary>
        public string ExternalCode { get; set; }

        /// <summary>
        /// Gets or sets the minimum price.
        /// </summary>
        public Price MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the sale prices.
        /// </summary>
        public Price[] SalePrices { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// </summary>
        public DateTime? Updated { get; set; }

        #endregion Properties
    }
}