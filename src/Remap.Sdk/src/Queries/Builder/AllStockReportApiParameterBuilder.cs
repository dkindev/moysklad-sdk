using System.Collections.Generic;
using Confiti.MoySklad.Remap.Extensions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an helper class to build API parameters for <see cref="AllStockReportQuery"/>.
    /// </summary>
    public class AllStockReportApiParameterBuilder : ApiParameterBuilder<AllStockReportQuery>
    {
        #region Fields

        private GroupBy? _groupBy;
        private bool? _includeRelated;

        #endregion Fields

        #region Methods

        /// <inheritdoc/>
        public override Dictionary<string, string> Build()
        {
            var query = base.Build();

            if (_groupBy.HasValue)
                query["groupBy"] = _groupBy.Value.GetParameterName();

            if (_includeRelated.HasValue)
                query["includeRelated"] = _includeRelated.Value.ToString().ToLower();

            return query;
        }

        /// <summary>
        /// Adds the parameter to group the result.
        /// </summary>
        /// <param name="groupBy">The parameter to group the result. The default value is <see cref="GroupBy.Variant"/>.</param>
        public void GroupBy(GroupBy groupBy)
        {
            _groupBy = groupBy;
        }

        /// <summary>
        /// Adds the parameter to displaying balances by product modifications and series.
        /// </summary>
        /// <param name="value">The parameter to displaying balances by product modifications and series.</param>
        public void IncludeRelated(bool value)
        {
            _includeRelated = value;
        }

        #endregion Methods
    }
}