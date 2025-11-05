using System;
using System.Collections.Generic;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Extensions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an helper class to build API parameters for <see cref="CurrentByStoreStockReportItem"/> query.
    /// </summary>
    public class CurrenByStoreStockReportApiParameterBuilder : CurrentStockReportApiParameterBuilder
    {
        #region Fields

        private bool? _withRecalculate;

        #endregion Fields

        #region Methods

        /// <inheritdoc/>
        public override Dictionary<string, string> Build()
        {
            var query = base.Build();

            if (_withRecalculate.HasValue)
                query["withRecalculate"] = _withRecalculate.Value.ToString().ToLower();

            return query;
        }

        /// <summary>
        /// Adds the parameter to add positions whose stocks are recalculated. The stock for such items will be displayed as <c>null</c>.
        /// After the recalculation is complete, the remaining stock will be displayed for such an item. Items that were created but not involved in any transactions are not displayed.
        /// </summary>
        /// <param name="value">The parameter to add positions whose stocks are recalculated.</param>
        public void WithRecalculate(bool value)
        {
            _withRecalculate = value;
        }

        #endregion Methods
    }

    /// <summary>
    /// Represents an helper class to build API parameters for <see cref="CurrentStockReportQuery"/>.
    /// </summary>
    public class CurrentStockReportApiParameterBuilder : ApiParameterBuilder<CurrentStockReportQuery>
    {
        #region Fields

        private string _changedSince;
        private StockIncludeType? _stockIncludeType;
        private StockType? _stockType;

        #endregion Fields

        #region Methods

        /// <inheritdoc/>
        public override Dictionary<string, string> Build()
        {
            var query = base.Build();

            if (!string.IsNullOrWhiteSpace(_changedSince))
                query["changedSince"] = _changedSince;

            if (_stockIncludeType.HasValue)
                query["include"] = _stockIncludeType.Value.GetParameterName();

            if (_stockType.HasValue)
                query["stockType"] = _stockType.Value.GetParameterName();

            return query;
        }

        /// <summary>
        /// Adds the parameter to get stock which have changed in the interval between the time specified in the changedSince parameter and the current moment.
        /// </summary>
        /// <param name="value">The parameter to get stock which have changed in the interval between the time specified in the changedSince parameter and the current moment.</param>
        /// <param name="format">The date time format.</param>
        public void ChangedSince(DateTime value, string format = ApiDefaults.DEFAULT_DATETIME_FORMAT)
        {
            _changedSince = value.ToString(format);
        }

        /// <summary>
        /// Adds the stock include type parameter. By default, only results with a non-zero balance are displayed. To display zero balances, add the <see cref="StockIncludeType.ZeroLines"/> parameter. Products that were created and not involved in any transactions are not displayed.
        /// </summary>
        /// <param name="stockIncludeType">The stock include type parameter.</param>
        public void Include(StockIncludeType stockIncludeType)
        {
            _stockIncludeType = stockIncludeType;
        }

        /// <summary>
        /// Adds the stock type parameter.
        /// </summary>
        /// <param name="stockType">The stock type parameter. The default value is <see cref="StockType.Stock"/>.</param>
        public void StockType(StockType stockType)
        {
            _stockType = stockType;
        }

        #endregion Methods
    }
}