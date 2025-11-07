using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an query for list of <see cref="ProfitReportItem"/>.
    /// See also: https://dev.moysklad.ru/doc/api/remap/1.2/#/reports/report-pnl#4-atributy-dostupnye-dlya-filtracii-otcheta-pribylnost-po-tovaram.
    /// </summary>
    public class ProfitReportQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets a string value with the name of the counterparty group by which to filter.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
        [Parameter("agentTag")]
        public string AgentTag { get; set; }

        /// <summary>
        /// Gets or sets a link to the counterparty by which you need to filter.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
        [Parameter("counterparty")]
        public CounterpartyQuery Counterparty { get; set; }

        /// <summary>
        /// Gets or sets a parameter for filtering by document type.
        /// <para/>
        /// List of all valid parameter values:
        /// <list type="bullet">
        ///     <item><see cref="EntityType.Demand"/></item>
        ///     <item><see cref="EntityType.RetailDemand"/></item>
        /// </list>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
        [Parameter("entityType")]
        public EntityType EntityType { get; set; }

        /// <summary>
        /// Gets or sets a link to the organization by which you need to filter.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
        [Parameter("organization")]
        public Organization Organization { get; set; }

        /// <summary>
        /// Gets or sets the parameter for filtering by multiple products.
        /// The parameter value is a link to the product to be included or excluded from the selection.
        /// Multiple values ​​can be passed.
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
        /// Gets or sets the parameter for filtering by product group. The parameter value is a reference to the product group to be included or excluded from the selection.
        /// Multiple values ​​can be passed.
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
        /// Gets or sets a link to the project by which you need to filter.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
        [Parameter("project")]
        public Project Project { get; set; }

        /// <summary>
        /// Gets or sets a link to the retail store by which you need to filter.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
        [Parameter("retailStore")]
        public RetailStore RetailStore { get; set; }

        /// <summary>
        /// Gets or sets a link to the sales channel by which you need to filter. Multiple values ​​can be passed.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(overriddenOperators: new[] { "=" })]
        [Parameter("salesChannel")]
        public SalesChannel SalesChannel { get; set; }

        /// <summary>
        /// Gets or sets a link to the store by which you need to filter.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
        [Parameter("store")]
        public Store Store { get; set; }

        /// <summary>
        /// Gets or sets a link to the supplier by which you need to filter.
        /// <para/>
        /// Use in actions:
        /// <list type="bullet">
        ///     <item>filtering</item>
        /// </list>
        /// </summary>
        [Filter(allowContinueConstraint: false, overriddenOperators: new[] { "=" })]
        [Parameter("supplier")]
        public CounterpartyQuery Supplier { get; set; }

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