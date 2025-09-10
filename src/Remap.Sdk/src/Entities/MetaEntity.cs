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
        public string AccountId { get; set; }

        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        public Guid? Id { get; set; }

        /// <inheritdoc/>
        public Meta Meta { get; set; }

        /// <summary>
        /// Gets or sets the entity name.
        /// </summary>
        public string Name { get; set; }

        #endregion Properties
    }
}