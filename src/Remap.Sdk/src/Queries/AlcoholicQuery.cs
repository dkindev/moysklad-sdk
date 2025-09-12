using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an query for <see cref="Alcoholic"/>.
    /// </summary>
    public class AlcoholicQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the code of the type product.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(overriddenOperators: new[] { "=", "!=" })]
        [Parameter("type")]
        public int? Type { get; set; }

        #endregion Properties
    }
}