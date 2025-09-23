using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an query for <see cref="ProductMetadata"/>.
    /// </summary>
    public class ProductMetadataQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the attributes.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("attributes")]
        public PagedEntities<AttributeDefinition> Attributes { get; set; }

        #endregion Properties
    }
}