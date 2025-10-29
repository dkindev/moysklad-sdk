namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an operation.
    /// </summary>
    public class Operation : IHasMeta<Meta>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the linked sum.
        /// </summary>
        public long? LinkedSum { get; set; }

        /// <inheritdoc/>
        public Meta Meta { get; set; }

        #endregion Properties
    }
}