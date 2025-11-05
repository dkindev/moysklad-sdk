namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents a stock type.
    /// </summary>
    public enum StockType
    {
        /// <summary>
        /// Uses to get the stock in warehouses, excluding reserves and transition periods.
        /// </summary>
        [Parameter("stock")]
        Stock,

        /// <summary>
        /// Uses to get the warehouse stock less reserve.
        /// </summary>
        [Parameter("freeStock")]
        FreeStock,

        /// <summary>
        /// Uses to get the available stock. Takes into account reserves and expectations.
        /// </summary>
        [Parameter("quantity")]
        Quantity,

        /// <summary>
        /// Uses to get the reserved stock.
        /// </summary>
        [Parameter("reserve")]
        Reserve,

        /// <summary>
        /// Uses to get the stock during the transition period.
        /// </summary>
        [Parameter("inTransit")]
        InTransit
    }
}