namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an variant.
    /// </summary>
    public class Variant : AbstractProduct
    {
        #region Properties

        /// <summary>
        /// Gets or sets the characteristics.
        /// </summary>
        public Characteristic[] Characteristics { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        public PagedEntities<Image> Images { get; set; }

        /// <summary>
        /// Gets or sets the packs.
        /// </summary>
        public Pack[] Packs { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the serial numbers.
        /// </summary>
        public string[] Things { get; set; }

        #endregion Properties
    }
}