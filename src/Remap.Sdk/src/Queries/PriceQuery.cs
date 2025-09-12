using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an query for <see cref="Price"/>.
    /// </summary>
    public class PriceQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the currency query.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("currency")]
        public CurrencyQuery Currency { get; set; }

        #endregion Properties
    }
}