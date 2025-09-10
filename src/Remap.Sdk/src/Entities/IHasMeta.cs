namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an object containing the paged metadata about entity.
    /// </summary>
    public interface IHasMeta<TMeta> where TMeta : Meta
    {
        /// <summary>
        /// Gets the metadata about entity.
        /// </summary>
        TMeta Meta { get; set; }
    }
}