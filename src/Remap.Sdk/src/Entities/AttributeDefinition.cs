namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an attribute definition.
    /// </summary>
    public class AttributeDefinition : AbstractAttribute
    {
        #region Properties

        /// <summary>
        /// Gets or sets the custom entity meta.
        /// </summary>
        public Meta CustomEntityMeta { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the attribute is required.
        /// </summary>
        public bool? Required { get; set; }

        #endregion Properties
    }
}