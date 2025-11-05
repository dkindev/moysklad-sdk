namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an assortment stock in each store.
    /// </summary>
    public class AssortmentStockByStore : IHasMeta<Meta>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the assortment metadata.
        /// </summary>
        public Meta Meta { get; set; }

        /// <summary>
        /// Gets or sets the stock in each store.
        /// </summary>
        public StockReportItemWithMetadata[] StockByStore { get; set; }

        #endregion Properties
    }
}