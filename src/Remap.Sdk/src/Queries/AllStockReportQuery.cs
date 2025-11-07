using System;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an query for list of <see cref="AllStockReportItem"/>.
    /// See also: https://dev.moysklad.ru/doc/api/remap/1.2/#/reports/report-stock#4-atributy-dostupnye-dlya-filtracii-dlya-rasshirennogo-otcheta.
    /// </summary>
    public class AllStockReportQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value for filtering by whether products are archived. Possible values: <c>true</c>, <c>false</c>. To return both archived and non-archived products, pass both values: <c>true</c> and <c>false</c>.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(overriddenOperators: new[] { "=" })]
        [Parameter("archived")]
        public bool Archived { get; set; }

        /// <summary>
        /// Gets or sets the average number of days in stock.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>ordering</item>
        /// </list>
        /// </summary>
        [AllowOrder]
        [Parameter("avgStockDays")]
        public double AvgStockDays { get; set; }

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
        /// Gets or sets the parameter for filtering by multiple series.
        /// The parameter value is a reference to the series to be included or excluded from the selection.
        /// Multiple values ​​can be passed. This filter parameter can be combined with the <see cref="Product"/> and <see cref="Variant"/> parameters.
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
        /// Gets or sets the count of the items in transit.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>ordering</item>
        /// </list>
        /// </summary>
        [AllowOrder]
        [Parameter("inTransit")]
        public double InTransit { get; set; }

        /// <summary>
        /// Gets or sets a parameter for filtering by the pending value. If <c>true</c>, only products with pending values ​​will be included in the selection.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
        [Parameter("inTransitOnly")]
        public bool InTransitOnly { get; set; }

        /// <summary>
        /// Gets or sets the minimum balance.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>ordering</item>
        /// </list>
        /// </summary>
        [AllowOrder]
        [Parameter("minimumBalance")]
        public double MinimumBalance { get; set; }

        /// <summary>
        /// Gets or sets the datetime at which the balances need to be withdrawn.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
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
        /// Gets or sets the cost price.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>ordering</item>
        /// </list>
        /// </summary>
        [AllowOrder]
        [Parameter("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the parameter for filtering by multiple products.
        /// The parameter value is a link to the product to be included or excluded from the selection.
        /// Multiple values ​​can be passed. This filter parameter can be combined with the <see cref="Consignment"/> and <see cref="Variant"/> parameters.
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
        /// Gets or sets the parameter for filtering by product group. The parameter value is a reference to the product group to be included or excluded from the selection. Only one value can be passed.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
        [Parameter("productFolder")]
        public ProductFolderQuery ProductFolder { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>ordering</item>
        /// </list>
        /// </summary>
        [AllowOrder]
        [Parameter("quantity")]
        public double Quantity { get; set; }

        /// <summary>
        /// Gets or sets the quantity mode. The default value is <see cref="QuantityMode.NonEmpty"/>.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
        [Parameter("quantityMode")]
        public QuantityMode QuantityMode { get; set; }

        /// <summary>
        /// Gets or sets the reserve.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>ordering</item>
        /// </list>
        /// </summary>
        [AllowOrder]
        [Parameter("reserve")]
        public double Reserve { get; set; }

        /// <summary>
        /// Gets or sets a parameter for filtering by the reserve value. If <c>true</c>, only products with a reserve will be included in the selection.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
        [Parameter("reserveOnly")]
        public bool ReserveOnly { get; set; }

        /// <summary>
        /// Gets or sets the sale price.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>ordering</item>
        /// </list>
        /// </summary>
        [AllowOrder]
        [Parameter("salePrice")]
        public decimal SalePrice { get; set; }

        /// <summary>
        /// Gets or sets the prefix search. The search is carried out by the inclusion of a substring in the names of products, modifications, and consignments.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(overriddenOperators: new[] { "=", "!=" })]
        [Parameter("search")]
        public string Search { get; set; }

        /// <summary>
        /// Gets or sets a parameter for filtering by weight of product. Possible values: <c>true</c>, <c>false</c>.
        /// <para/>
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
        [Parameter("soldByWeight")]
        public bool SoldByWeight { get; set; }

        /// <summary>
        /// Gets or sets the stock.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>ordering</item>
        /// </list>
        /// </summary>
        [AllowOrder]
        [Parameter("stock")]
        public double Stock { get; set; }

        /// <summary>
        /// Gets or sets a parameter for filtering by the number of days in stock. An integer must be passed.
        /// Products with the number of days in stock greater than or equal to the specified number will be included in the selection.
        /// This filtering parameter can be combined with the <see cref="StockDaysTo"/> parameter.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
        [Parameter("stockDaysFrom")]
        public double StockDaysFrom { get; set; }

        /// <summary>
        /// Gets or sets a parameter for filtering by the number of days in stock. An integer must be passed.
        /// Products with the number of days in stock less than or equal to the specified number will be included in the selection.
        /// This filtering parameter can be combined with the <see cref="StockDaysFrom"/> parameter.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
        [Parameter("stockDaysTo")]
        public double StockDaysTo { get; set; }

        /// <summary>
        /// Gets or sets the stock mode. The default value is <see cref="StockMode.All"/>.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
        [Parameter("stockMode")]
        public StockMode StockMode { get; set; }

        /// <summary>
        /// Gets or sets the parameter for filtering across multiple warehouses. The parameter value is a reference to the warehouse to be included in or excluded from the selection. Multiple values ​​can be passed.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(overriddenOperators: new[] { "=", "!=" })]
        [Parameter("store")]
        public Store Store { get; set; }

        /// <summary>
        /// Gets or sets the total sum.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>ordering</item>
        /// </list>
        /// </summary>
        [AllowOrder]
        [Parameter("sumTotal")]
        public decimal SumTotal { get; set; }

        /// <summary>
        /// Gets or sets the parameter for filtering by multiple suppliers. The parameter value is a reference to a counterparty or organization.
        /// The products with the specified suppliers will be included or excluded from the selection.
        /// You can pass an empty value, in which case products with either an empty or specified supplier will be included in the selection.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(overriddenOperators: new[] { "=", "!=" })]
        [Parameter("supplier")]
        public CounterpartyQuery Supplier { get; set; }

        /// <summary>
        /// Gets or sets the parameter for filtering by multiple variants.
        /// The parameter value is a reference to the modification to be included or excluded from the selection.
        /// Multiple values ​​can be passed. This filter parameter can be combined with the <see cref="Product"/> and <see cref="Consignment"/> parameters.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(overriddenOperators: new[] { "=", "!=" })]
        [Parameter("variant")]
        public VariantQuery Variant { get; set; }

        /// <summary>
        /// Gets or sets a parameter for considering nested subgroups. Only works if there is a filter on <see cref="ProductFolder"/>.
        /// By default, <c>true</c> displays products from child subgroups of the filtered product group(s).
        /// If <c>false</c> is passed, only products from the filtered group(s) are displayed, ignoring subgroups.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
        [Parameter("withSubFolders")]
        public bool WithSubFolders { get; set; }

        #endregion Properties
    }
}