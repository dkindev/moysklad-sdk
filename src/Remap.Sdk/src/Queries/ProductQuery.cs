using Confiti.MoySklad.Remap.Entities;
using Remap.Sdk.Queries;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an query for <see cref="Product"/>.
    /// See also: https://dev.moysklad.ru/doc/api/remap/1.2/dictionaries/#suschnosti-kontragent-kontragenty.
    /// </summary>
    public class ProductQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the buy price query.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("buyPrice")]
        public PriceQuery BuyPrice { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("country")]
        public Country Country { get; set; }

        /// <summary>
        /// Gets or sets the files.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("files")]
        public PagedEntities<File> Files { get; set; }

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
        /// Gets or sets the images.
        /// <see cref="AllowExpandAttribute"/>
        /// </summary>
        [AllowExpand]
        [Parameter("images")]
        public PagedEntities<Image> Images { get; set; }

        /// <summary>
        /// Gets or sets the minimum price query.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("minPrice")]
        public PriceQuery MinPrice { get; set; }

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
        /// Gets or sets the packs.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("packs")]
        public PacksQuery Packs { get; set; }

        /// <summary>
        /// Gets or sets the product folder.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("productFolder")]
        public ProductFolderQuery ProductFolder { get; set; }

        /// <summary>
        /// Gets or sets the sale prices query.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("salePrices")]
        public PriceQuery SalePrices { get; set; }

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
        /// Gets or sets the unit of measure.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("uom")]
        public UomQuery Uom { get; set; }

        #endregion Properties
    }
}