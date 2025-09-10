namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents the metadata about entity.
    /// </summary>
    public class Meta
    {
        #region Properties

        /// <summary>
        /// Gets or sets the download reference.
        /// </summary>
        public string DownloadHref { get; set; }

        /// <summary>
        /// Gets or sets the entity reference.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Gets or sets the media type.
        /// </summary>
        public string MediaType { get; set; }

        /// <summary>
        /// Gets or sets the entity metadata reference.
        /// </summary>
        public string MetadataHref { get; set; }

        /// <summary>
        /// Gets or sets the type of entity.
        /// </summary>
        public EntityType Type { get; set; }

        /// <summary>
        /// Gets or sets the entity reference located in the UI.
        /// </summary>
        public string UuidHref { get; set; }

        #endregion Properties
    }
}