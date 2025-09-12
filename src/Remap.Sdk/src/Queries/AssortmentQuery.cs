using System;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an query for list of <see cref="Assortment"/>.
    /// See also: https://dev.moysklad.ru/doc/api/remap/1.2/dictionaries/#suschnosti-assortiment.
    /// </summary>
    public class AssortmentQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the alcoholic product information. If set, then <see cref="Service"/>'s and <see cref="Bundle"/>'s are ignored.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(allowNesting: true, allowFilterByRootNestingMember: false)]
        [Parameter("alcoholic")]
        public AlcoholicQuery Alcoholic { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is archived.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [Parameter("archived")]
        public bool Archived { get; set; }

        /// <summary>
        /// Gets or sets the article.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("article")]
        public string Article { get; set; }

        /// <summary>
        /// Gets or sets the barcode.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [Parameter("barcode")]
        public string Barcode { get; set; }

        /// <summary>
        /// Gets or sets the buy price query.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("buyPrice")]
        public PriceQuery BuyPrice { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the components query.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("components")]
        public BundleComponentQuery Components { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the external code.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("externalCode")]
        public string ExternalCode { get; set; }

        /// <summary>
        /// Gets or sets the path name for filtering.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [Parameter("pathname")]
        public string FilterByPathName { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(allowNull: false)]
        [AllowExpand]
        [Parameter("group")]
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets the ID.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("images")]
        public PagedEntities<Image> Images { get; set; }

        /// <summary>
        /// Gets or sets the count of the items in transit.
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [AllowOrder]
        [Parameter("inTransit")]
        public double InTransit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity should be alcoholic.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(allowNull: false, allowContinueConstraint: false)]
        [Parameter("alcoholic")]
        public bool IsAlcoholic { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity should be tracked with serial number.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(allowContinueConstraint: false)]
        [Parameter("isSerialTrackable")]
        public bool IsSerialTrackable { get; set; }

        /// <summary>
        /// Gets or sets the minimum price query.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("minPrice")]
        public PriceQuery MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(allowNull: false)]
        [AllowOrder]
        [Parameter("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowExpand]
        [Parameter("owner")]
        public Employee Owner { get; set; }

        /// <summary>
        /// Gets or sets the path name.
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [AllowOrder]
        [Parameter("pathName")]
        public string PathName { get; set; }

        /// <summary>
        /// Gets or sets the product query.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("product")]
        public ProductQuery Product { get; set; }

        /// <summary>
        /// Gets or sets the product folder.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowExpand]
        [Parameter("productFolder")]
        public ProductFolderQuery ProductFolder { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [AllowOrder]
        [Parameter("quantity")]
        public double Quantity { get; set; }

        /// <summary>
        /// Gets or sets the quantity mode. If set, then <see cref="Service"/>'s and <see cref="Bundle"/>'s are ignored.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [Parameter("quantityMode")]
        public QuantityMode QuantityMode { get; set; }

        /// <summary>
        /// Gets or sets the reserve.
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [AllowOrder]
        [Parameter("reserve")]
        public double Reserve { get; set; }

        /// <summary>
        /// Gets or sets the sale prices query.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("salePrices")]
        public PriceQuery SalePrices { get; set; }

        /// <summary>
        /// Gets or sets the path name.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(overriddenOperators: new[] { "=" })]
        [Parameter("search")]
        public string Search { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is shared.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(allowContinueConstraint: false)]
        [Parameter("shared")]
        public bool Shared { get; set; }

        /// <summary>
        /// Gets or sets the stock.
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [AllowOrder]
        [Parameter("stock")]
        public double Stock { get; set; }

        /// <summary>
        /// Gets or sets the stock mode. If set, then <see cref="Service"/>'s and <see cref="Bundle"/>'s are ignored.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [Parameter("stockMode")]
        public StockMode StockMode { get; set; }

        /// <summary>
        /// Gets or sets the datetime at which the balances need to be withdrawn.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [Parameter("stockMoment")]
        public DateTime StockMoment { get; set; }

        /// <summary>
        /// Gets or sets the stock store.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [Parameter("stockStore")]
        public Store StockStore { get; set; }

        /// <summary>
        /// Gets or sets the supplier.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowExpand]
        [Parameter("supplier")]
        public CounterpartyQuery Supplier { get; set; }

        /// <summary>
        /// Gets or sets the entity type.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(overriddenOperators: new[] { "=" })]
        [Parameter("type")]
        public EntityType Type { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("updated")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets the parameter to filter by author of the latest update.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(allowNull: false, overriddenOperators: new[] { "=", "!=" })]
        [Parameter("updatedBy")]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is Weighed. If set, then <see cref="Service"/>'s and <see cref="Bundle"/>'s are ignored.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(allowContinueConstraint: false)]
        [Parameter("weighed")]
        public bool Weighed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the assortment will be displayed taking into account subgroups.
        /// Works only if there is a non-empty filter by productFolder.
        /// By default, true, products from child subgroups of the filtered product group / groups are displayed.
        /// When false is passed, only products from the filtered group / groups are displayed, without taking into account subgroups.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(allowContinueConstraint: false)]
        [Parameter("withSubFolders")]
        public bool WithSubFolders { get; set; }

        #endregion Properties
    }
}