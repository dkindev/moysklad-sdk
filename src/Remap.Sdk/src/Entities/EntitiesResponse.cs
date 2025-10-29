namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents the response containing the list of entities with <see cref="Context"/>.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public class EntitiesResponse<T> : PagedEntities<T>, IHasContext
    {
        #region Properties

        /// <inheritdoc/>
        public Context Context { get; set; }

        #endregion Properties
    }
}