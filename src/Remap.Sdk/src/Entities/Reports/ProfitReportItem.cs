namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an report profit item by assortment.
    /// </summary>
    public class ProfitByAssortmentReportItem : ProfitReportItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the assortment information.
        /// </summary>
        public Assortment Assortment { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an report profit item by product.
    /// </summary>
    public class ProfitByCounterpartyReportItem : ProfitReportItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Counterparty information.
        /// </summary>
        public Counterparty Counterparty { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an report profit item by employee.
    /// </summary>
    public class ProfitByEmployeeReportItem : ProfitReportItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Employee information.
        /// </summary>
        public Employee Employee { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an report profit item by sales channel.
    /// </summary>
    public class ProfitBySalesChannelReportItem : ProfitReportItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the sales channel information.
        /// </summary>
        public SalesChannel SalesChannel { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an report profit item.
    /// </summary>
    public abstract class ProfitReportItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the margin of the items.
        /// </summary>
        public double? Margin { get; set; }

        /// <summary>
        /// Gets or sets the profit of the items.
        /// </summary>
        public double? Profit { get; set; }

        /// <summary>
        /// Gets or sets the return price of the item.
        /// </summary>
        public double? ReturnCost { get; set; }

        /// <summary>
        /// Gets or sets the return cost sum of the items.
        /// </summary>
        public double? ReturnCostSum { get; set; }

        /// <summary>
        /// Gets or sets the return price of the item.
        /// </summary>
        public double? ReturnPrice { get; set; }

        /// <summary>
        /// Gets or sets the returned count of the items.
        /// </summary>
        public double? ReturnQuantity { get; set; }

        /// <summary>
        /// Gets or sets the return sum of the items.
        /// </summary>
        public double? ReturnSum { get; set; }

        /// <summary>
        /// Gets or sets the sell price of the item.
        /// </summary>
        public double? SellCost { get; set; }

        /// <summary>
        /// Gets or sets the sell cost sum of the items.
        /// </summary>
        public double? SellCostSum { get; set; }

        /// <summary>
        /// Gets or sets the price of the sold item.
        /// </summary>
        public double? SellPrice { get; set; }

        /// <summary>
        /// Gets or sets the count of the sold items.
        /// </summary>
        public double? SellQuantity { get; set; }

        /// <summary>
        /// Gets or sets the sell sum of the items.
        /// </summary>
        public double? SellSum { get; set; }

        #endregion Properties
    }
}