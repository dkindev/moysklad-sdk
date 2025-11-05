using System;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an query for list of <see cref="CurrentStockReportItem"/>.
    /// See also: https://dev.moysklad.ru/doc/api/remap/1.2/#/reports/report-stock#4-dostupnye-filtry-otchyota-tekushie-ostatki.
    /// </summary>
    public class CurrentStockReportQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the assortment ID.
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(overriddenOperators: new[] { "=" })]
        [Parameter("assortmentId")]
        public Guid AssortmentId { get; set; }

        /// <summary>
        /// Gets or sets the store ID.
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(overriddenOperators: new[] { "=" })]
        [Parameter("storeId")]
        public Guid StoreId { get; set; }

        #endregion Properties
    }
}