namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents a stock include type.
    /// </summary>
    public enum StockIncludeType
    {
        /// <summary>
        /// Uses to get the assortment with zero stock quantity.
        /// </summary>
        [Parameter("zeroLines")]
        ZeroLines
    }
}