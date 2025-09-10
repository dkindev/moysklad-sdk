using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an assortment.
    /// </summary>
    public class Assortment : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the count of the items in transit.
        /// </summary>
        public double? InTransit { get; set; }

        /// <summary>
        /// Gets or sets the abstract product.
        /// </summary>
        [JsonIgnore]
        public AbstractProduct Product { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public double? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the reserve.
        /// </summary>
        public double? Reserve { get; set; }

        /// <summary>
        /// Gets or sets the stock.
        /// </summary>
        public double? Stock { get; set; }

        #endregion Properties
    }
}