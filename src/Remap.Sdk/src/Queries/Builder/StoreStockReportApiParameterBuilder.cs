using System.Collections.Generic;
using Confiti.MoySklad.Remap.Extensions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an helper class to build API parameters for <see cref="StoreStockReportQuery"/>.
    /// </summary>
    public class StoreStockReportApiParameterBuilder : ApiParameterBuilder<StoreStockReportQuery>
    {
        #region Fields

        private GroupBy? _groupBy;

        #endregion Fields

        #region Methods

        /// <inheritdoc/>
        public override Dictionary<string, string> Build()
        {
            var query = base.Build();

            if (_groupBy.HasValue)
                query["groupBy"] = _groupBy.Value.GetParameterName();

            return query;
        }

        /// <summary>
        /// Adds the parameter to group the result.
        /// </summary>
        /// <param name="groupBy">The parameter to group the result.
        /// Takes one of the values:
        /// <see cref="GroupBy.Product"/> - only products will be displayed,
        /// <see cref="GroupBy.Variant"/> - products and modifications will be displayed (similar to the absence of the parameter),
        /// <see cref="GroupBy.Consignment"/> - all entities will be displayed.</param>
        public void GroupBy(GroupBy groupBy)
        {
            _groupBy = groupBy;
        }

        #endregion Methods
    }
}