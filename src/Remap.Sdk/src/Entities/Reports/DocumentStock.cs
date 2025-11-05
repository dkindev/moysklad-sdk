using Confiti.MoySklad.Remap.Entities;

namespace Remap.Sdk.Entities.Reports
{
    /// <summary>
    /// Represents an assortment stock in document.
    /// </summary>
    public class DocumentStock : IHasMeta<Meta>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the document metadata.
        /// </summary>
        public Meta Meta { get; set; }

        /// <summary>
        /// Gets or sets the stock in each store.
        /// </summary>
        public AssortmentStockReportItem[] Positions { get; set; }

        #endregion Properties
    }
}