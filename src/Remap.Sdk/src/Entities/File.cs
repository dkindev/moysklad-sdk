namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an file.
    /// </summary>
    public class File : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        /// <value>The filename.</value>
        public string Filename { get; set; }

        #endregion Properties
    }
}