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
        /// <value>The characteristics.</value>
        public Characteristic[] Characteristics { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>The images.</value>
        public PagedEntities<Image> Images { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the serial numbers.
        /// </summary>
        /// <value>The serial numbers.</value>
        public string[] Things { get; set; }

        #endregion Properties
    }
}
