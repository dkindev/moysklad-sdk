using System;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents a assortment query.
    /// See also: https://dev.moysklad.ru/doc/api/remap/1.2/dictionaries/#suschnosti-assortiment.
    /// </summary>
    public class AssortmentQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the alcoholic product information. If set, then <see cref="Service"/>'s and <see cref="Bundle"/>'s are ignored.
        /// Note: 'filter' (nested) is allowed.
        /// </summary>
        /// <value>The alcoholic product information.</value>
        [Filter(allowNesting: true, allowFilterByRootNestingMember: false)]
        [Parameter("alcoholic")]
        public AlcoholicQuery Alcoholic { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is archived.
        /// Note: 'filter' is allowed.
        /// </summary>
        /// <value>The value indicating whether to the entity is archived.</value>
        [Filter]
        [Parameter("archived")]
        public bool Archived { get; set; }

        /// <summary>
        /// Gets or sets the article.
        /// Note: 'filter', 'order' are allowed.
        /// </summary>
        /// <value>The article.</value>
        [Filter]
        [AllowOrder]
        [Parameter("article")]
        public string Article { get; set; }

        /// <summary>
        /// Gets or sets the buy price query.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The buy price query.</value>
        [AllowExpand]
        [Parameter("buyPrice")]
        public PriceQuery BuyPrice { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// Note: 'filter', 'order' are allowed.
        /// </summary>
        /// <value>The code.</value>
        [Filter]
        [AllowOrder]
        [Parameter("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the components query.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The components query.</value>
        [AllowExpand]
        [Parameter("components")]
        public BundleComponentQuery Components { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// Note: 'filter' is allowed.
        /// </summary>
        /// <value>The description.</value>
        [Filter]
        [Parameter("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the external code.
        /// Note: 'filter' is allowed.
        /// </summary>
        /// <value>The external code.</value>
        [Filter]
        [Parameter("externalCode")]
        public string ExternalCode { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// Note: 'filter', 'expand' are allowed.
        /// </summary>
        /// <value>The group.</value>
        [Filter(allowNull: false)]
        [AllowExpand]
        [Parameter("group")]
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets the entity id.
        /// Note: 'filter' is allowed.
        /// </summary>
        /// <value>The entity id.</value>
        [Filter]
        [Parameter("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The images.</value>
        [AllowExpand]
        [Parameter("images")]
        public PagedEntities<Image> Images { get; set; }

        /// <summary>
        /// Gets or sets the count of the items in transit.
        /// Note: 'order' is allowed.
        /// </summary>
        /// <value>The count of the items in transit.</value>
        [AllowOrder]
        [Parameter("inTransit")]
        public double InTransit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity should be alcoholic.
        /// Note: 'filter' is allowed.
        /// </summary>
        /// <value>The value indicating whether to the entity should be alcoholic.</value>
        [Filter(allowNull: false, allowContinueConstraint: false)]
        [Parameter("alcoholic")]
        public bool IsAlcoholic { get; set; }

        /// <summary>
        /// Gets or sets the entity name.
        /// Note: 'filter', 'order' are allowed.
        /// </summary>
        /// <value>The entity name.</value>
        [Filter(allowNull: false)]
        [AllowOrder]
        [Parameter("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// Note: 'filter', 'expand' are allowed.
        /// </summary>
        /// <value>The owner.</value>
        [Filter]
        [AllowExpand]
        [Parameter("owner")]
        public Employee Owner { get; set; }

        /// <summary>
        /// Gets or sets the path name.
        /// Note: 'order' is allowed.
        /// </summary>
        /// <value>The path name.</value>
        [AllowOrder]
        [Parameter("pathName")]
        public string PathName { get; set; }

        /// <summary>
        /// Gets or sets the product query.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The product query.</value>
        [AllowExpand]
        [Parameter("product")]
        public ProductQuery Product { get; set; }

        /// <summary>
        /// Gets or sets the product folder.
        /// Note: 'filter', 'expand' are allowed.
        /// </summary>
        /// <value>The product folder.</value>
        [Filter]
        [AllowExpand]
        [Parameter("productFolder")]
        public ProductFolder ProductFolder { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// Note: 'order' is allowed.
        /// </summary>
        /// <value>The quantity.</value>
        [AllowOrder]
        [Parameter("quantity")]
        public double Quantity { get; set; }

        /// <summary>
        /// Gets or sets the quantity mode. If set, then <see cref="Service"/>'s and <see cref="Bundle"/>'s are ignored.
        /// Note: 'filter' is allowed.
        /// </summary>
        /// <value>The quantity mode.</value>
        [Filter]
        [Parameter("quantityMode")]
        public QuantityMode QuantityMode { get; set; }

        /// <summary>
        /// Gets or sets the reserve.
        /// Note: 'order' is allowed.
        /// </summary>
        /// <value>The reserve.</value>
        [AllowOrder]
        [Parameter("reserve")]
        public double Reserve { get; set; }

        /// <summary>
        /// Gets or sets the sale prices query.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The sale prices query.</value>
        [AllowExpand]
        [Parameter("salePrices")]
        public PriceQuery SalePrices { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is shared.
        /// Note: 'filter' is allowed.
        /// </summary>
        /// <value>The value indicating whether to the entity is shared.</value>
        [Filter(allowContinueConstraint: false)]
        [Parameter("shared")]
        public bool Shared { get; set; }

        /// <summary>
        /// Gets or sets the stock.
        /// Note: 'order' is allowed.
        /// </summary>
        /// <value>The stock.</value>
        [AllowOrder]
        [Parameter("stock")]
        public double Stock { get; set; }

        /// <summary>
        /// Gets or sets the stock mode. If set, then <see cref="Service"/>'s and <see cref="Bundle"/>'s are ignored.
        /// Note: 'filter' is allowed.
        /// </summary>
        /// <value>The stock mode.</value>
        [Filter]
        [Parameter("stockMode")]
        public StockMode StockMode { get; set; }

        /// <summary>
        /// Gets or sets the stock store.
        /// Note: 'filter' is allowed.
        /// </summary>
        /// <value>The stock store.</value>
        [Filter]
        [Parameter("stockStore")]
        public Store StockStore { get; set; }

        /// <summary>
        /// Gets or sets the supplier.
        /// Note: 'filter', 'expand' are allowed.
        /// </summary>
        /// <value>The supplier.</value>
        [Filter]
        [AllowExpand]
        [Parameter("supplier")]
        public Counterparty Supplier { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// Note: 'filter' is allowed.
        /// </summary>
        /// <value>The date when the entity has been updated.</value>
        [Filter]
        [Parameter("updated")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets the parameter to filter by author of the latest update.
        /// Note: 'filter' is allowed.
        /// </summary>
        /// <value>The parameter to filter by author of the latest update.</value>
        [Filter(allowNull: false, overriddenOperators: new[] { "=", "!=" })]
        [Parameter("updatedBy")]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is Weighed. If set, then <see cref="Service"/>'s and <see cref="Bundle"/>'s are ignored.
        /// Note: 'filter' is allowed.
        /// </summary>
        /// <value>The value indicating whether to the entity is Weighed.</value>
        [Filter(allowContinueConstraint: false)]
        [Parameter("weighed")]
        public bool Weighed { get; set; }

        #endregion Properties
    }
}