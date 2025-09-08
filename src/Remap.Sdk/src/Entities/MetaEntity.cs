using System;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an entity containing <see cref="Entities.Meta"/>.
    /// </summary>
    public abstract class MetaEntity : IHasMeta<Meta>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the account id.
        /// </summary>
        /// <value>The account id.</value>
        public string AccountId { get; set; }

        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        /// <value>The entity id.</value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets the metadata about entity.
        /// </summary>
        /// <value>The metadata about entity.</value>
        public Meta Meta { get; set; }

        /// <summary>
        /// Gets or sets the entity name.
        /// </summary>
        /// <value>The entity name.</value>
        public string Name { get; set; }

        #endregion Properties
    }
}