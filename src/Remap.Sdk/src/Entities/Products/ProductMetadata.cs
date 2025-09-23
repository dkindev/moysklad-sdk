namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an product metadata.
    /// </summary>
    public class ProductMetadata : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        public PagedEntities<AttributeDefinition> Attributes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the products should be created as shared.
        /// </summary>
        public bool CreateShared { get; set; }

        #endregion Properties
    }
}