using System;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an item for full stock report.
    /// </summary>
    public class AllStockReportItem : StockReportItemWithMetadata
    {
        #region Properties

        /// <summary>
        /// Gets or sets the article.
        /// </summary>
        public string Article { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the external code.
        /// </summary>
        public string ExternalCode { get; set; }

        /// <summary>
        /// Gets or sets the folder.
        /// </summary>
        public ProductFolder Folder { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the sale price.
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// Gets or sets the number of days in stock.
        /// </summary>
        public double StockDays { get; set; }

        /// <summary>
        /// Gets or sets the unit of measure.
        /// </summary>
        public Uom Uom { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an item for stock report grouped by assortment in document.
    /// </summary>
    public class AssortmentStockReportItem : StockReportItemWithMetadata
    {
        #region Properties

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        public decimal Cost { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an item for stock report grouped by assortment, stores and slots.
    /// </summary>
    public class CurrentBySlotStockReportItem : CurrentStockReportItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the slot ID.
        /// </summary>
        public Guid SlotId { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an item for stock report grouped by assortment and stores.
    /// </summary>
    public class CurrentByStoreStockReportItem : CurrentStockReportItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the store ID.
        /// </summary>
        public Guid StoreId { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an item for stock report grouped by assortment.
    /// </summary>
    public class CurrentStockReportItem : StockReportItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the assortment ID.
        /// </summary>
        public Guid AssortmentId { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an item for stock report.
    /// </summary>
    public class StockReportItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the count of the items in transit.
        /// </summary>
        public double? InTransit { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public double? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the reserve.
        /// </summary>
        public double? Reserve { get; set; }

        /// <summary>
        /// Gets or sets the stock.
        /// </summary>
        public double? Stock { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an item for stock report with metadata.
    /// </summary>
    public class StockReportItemWithMetadata : StockReportItem, IHasMeta<Meta>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the store metadata.
        /// </summary>
        public Meta Meta { get; set; }

        /// <summary>
        /// Gets or sets the store name.
        /// </summary>
        public string Name { get; set; }

        #endregion Properties
    }
}