using System;
using Confiti.MoySklad.Remap.Client.Json;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an document.
    /// </summary>
    public abstract class Document : MetaEntity, ISynchronizationSupported
    {
        #region Properties

        /// <summary>
        /// Gets or sets the date when the entity has been created.
        /// </summary>
        /// <value>The date when the entity has been created.</value>
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been deleted.
        /// </summary>
        /// <value>The date when the entity has been deleted.</value>
        public DateTime? Deleted { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the external code.
        /// </summary>
        /// <value>The external code.</value>
        public string ExternalCode { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>The group.</value>
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets the date when the document has been placed.
        /// </summary>
        /// <value>The date when the document has been placed.</value>
        public DateTime? Moment { get; set; }

        /// <summary>
        /// Gets or sets the organization.
        /// </summary>
        /// <value>The organization.</value>
        public Organization Organization { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>The owner.</value>
        [EmptyObjectValue]
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Employee Owner { get; set; } = new Employee();

        /// <summary>
        /// Gets or sets the value indicating whether to the document has been printed.
        /// </summary>
        /// <value>The value indicating whether to the document has been printed.</value>
        public bool? Printed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the document is published.
        /// </summary>
        /// <value>The value indicating whether to the document is published.</value>
        public bool? Published { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is shared.
        /// </summary>
        /// <value>The value indicating whether to the entity is shared.</value>
        public bool? Shared { get; set; }

        /// <summary>
        /// Gets or sets the synchronization id.
        /// </summary>
        /// <value>The synchronization id.</value>
        public string SyncId { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// </summary>
        /// <value>The date when the entity has been updated.</value>
        public DateTime? Updated { get; set; }

        #endregion Properties
    }
}