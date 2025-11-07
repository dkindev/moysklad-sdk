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

        /// <summary>
        /// Gets or sets the return price of the item.
        /// </summary>
        public decimal? ReturnCost { get; set; }

        /// <summary>
        /// Gets or sets the return price of the item.
        /// </summary>
        public decimal? ReturnPrice { get; set; }

        /// <summary>
        /// Gets or sets the returned count of the items.
        /// </summary>
        public double? ReturnQuantity { get; set; }

        /// <summary>
        /// Gets or sets the sell price of the item.
        /// </summary>
        public decimal? SellCost { get; set; }

        /// <summary>
        /// Gets or sets the price of the sold item.
        /// </summary>
        public decimal? SellPrice { get; set; }

        /// <summary>
        /// Gets or sets the count of the sold items.
        /// </summary>
        public double? SellQuantity { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an report profit item by product.
    /// </summary>
    public class ProfitByCounterpartyReportItem : ProfitByPersonReportItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the counterparty information.
        /// </summary>
        public Counterparty Counterparty { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an report profit item by employee.
    /// </summary>
    public class ProfitByEmployeeReportItem : ProfitByPersonReportItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the employee information.
        /// </summary>
        public Employee Employee { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an report profit item by person.
    /// </summary>
    public class ProfitByPersonReportItem : ProfitReportItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the avarage returns sum.
        /// </summary>
        public decimal? ReturnAvgCheck { get; set; }

        /// <summary>
        /// Gets or sets the returns count.
        /// </summary>
        public int? ReturnCount { get; set; }

        /// <summary>
        /// Gets or sets the avarage sales sum.
        /// </summary>
        public decimal? SalesAvgCheck { get; set; }

        /// <summary>
        /// Gets or sets the sales count
        /// </summary>
        public int? SallesCount { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an report profit item by sales channel.
    /// </summary>
    public class ProfitBySalesChannelReportItem : ProfitByPersonReportItem
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
        public decimal? Profit { get; set; }

        /// <summary>
        /// Gets or sets the return cost sum of the items.
        /// </summary>
        public decimal? ReturnCostSum { get; set; }

        /// <summary>
        /// Gets or sets the return sum of the items.
        /// </summary>
        public decimal? ReturnSum { get; set; }

        /// <summary>
        /// Gets or sets the sells profitability.
        /// </summary>
        public double? SalesMargin { get; set; }

        /// <summary>
        /// Gets or sets the sell cost sum of the items.
        /// </summary>
        public decimal? SellCostSum { get; set; }

        /// <summary>
        /// Gets or sets the sell sum of the items.
        /// </summary>
        public decimal? SellSum { get; set; }

        #endregion Properties
    }
}