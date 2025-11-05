using System;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an query for list of <see cref="AssortmentStockByStore"/>.
    /// See also: https://dev.moysklad.ru/doc/api/remap/1.2/#/reports/report-stock#4-atributy-dostupnye-dlya-filtracii.
    /// </summary>
    public class StoreStockReportQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the code.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>ordering</item>
        /// </list>
        /// </summary>
        [AllowOrder]
        [Parameter("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the parameter for filtering by consignment.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter]
        [Parameter("consignment")]
        public Consignment Consignment { get; set; }

        /// <summary>
        /// Gets or sets the datetime at which the balances need to be withdrawn.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter]
        [Parameter("moment")]
        public DateTime Moment { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>ordering</item>
        /// </list>
        /// </summary>
        [AllowOrder]
        [Parameter("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the path name.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>ordering</item>
        /// </list>
        /// </summary>
        [AllowOrder]
        [Parameter("pathName")]
        public string PathName { get; set; }

        /// <summary>
        /// Gets or sets the parameter for filtering by product.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter]
        [Parameter("product")]
        public ProductQuery Product { get; set; }

        /// <summary>
        /// Gets or sets the article.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>ordering</item>
        /// </list>
        /// </summary>
        [AllowOrder]
        [Parameter("productCode")]
        public string ProductCode { get; set; }

        /// <summary>
        /// Gets or sets the parameter for filtering by product group.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter]
        [Parameter("productFolder")]
        public ProductFolderQuery ProductFolder { get; set; }

        /// <summary>
        /// Gets or sets the prefix search. The search is carried out by the inclusion of a substring in the names of products, modifications, and consignments.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(overriddenOperators: new[] { "=" })]
        [Parameter("search")]
        public string Search { get; set; }

        /// <summary>
        /// Gets or sets a parameter for filtering by weight of product. Possible values: <c>true</c>, <c>false</c>.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter]
        [Parameter("soldByWeight")]
        public bool SoldByWeight { get; set; }

        /// <summary>
        /// Gets or sets the stock mode. The default value is <see cref="StockMode.NonEmpty"/>.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter]
        [Parameter("stockMode")]
        public StockMode StockMode { get; set; }

        /// <summary>
        /// Gets or sets the stock on all stores.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>ordering</item>
        /// </list>
        /// </summary>
        [AllowOrder]
        [Parameter("stockOnAllStores")]
        public double StockOnAllStores { get; set; }

        /// <summary>
        /// Gets or sets the parameter for filtering across multiple warehouses.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter]
        [Parameter("store")]
        public Store Store { get; set; }

        /// <summary>
        /// Gets or sets the parameter for filtering by multiple suppliers. The parameter value is a reference to a counterparty or organization.
        /// The products with the specified suppliers will be included or excluded from the selection.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter]
        [Parameter("supplier")]
        public CounterpartyQuery Supplier { get; set; }

        /// <summary>
        /// Gets or sets the parameter for filtering by multiple variants.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter]
        [Parameter("variant")]
        public Variant Variant { get; set; }

        #endregion Properties
    }
}