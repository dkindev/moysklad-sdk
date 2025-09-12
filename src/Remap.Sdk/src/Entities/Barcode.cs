namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an barcode.
    /// </summary>
    public class Barcode
    {
        #region Properties

        /// <summary>
        /// Gets or sets the barcode type.
        /// </summary>
        public BarcodeType Type { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }

        #endregion Properties
    }
}