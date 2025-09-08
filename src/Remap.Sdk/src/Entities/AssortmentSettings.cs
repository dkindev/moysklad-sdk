using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an assortment barcode rules.
    /// </summary>
    public class AssortmentBarcodeRules
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to the EAN13 will be automatically generated for new goods.
        /// </summary>
        public bool FillEAN13Barcode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the barcode prefixes will be used for weighed goods.
        /// </summary>
        public bool WeightBarcode { get; set; }

        /// <summary>
        /// Gets or sets a barcode prefix for weighed goods. Available values: number with X or XX format.
        /// </summary>
        public int WeightBarcodePrefix { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an assortment settings.
    /// </summary>
    public class AssortmentSettings : IHasMeta<Meta>
    {
        #region Properties

        /// <summary>
        /// Gets or sets a barcode rules.
        /// </summary>
        public AssortmentBarcodeRules BarcodeRules { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the new entities will be created with "Shared" mark.
        /// </summary>
        public bool CreatedShared { get; set; }

        /// <inheritdoc/>
        public Meta Meta { get; set; }

        /// <summary>
        /// Gets or sets a unique code rules.
        /// </summary>
        public AssortmentUniqueCodeRules UniqueCodeRules { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an assortment unique code rules.
    /// </summary>
    public class AssortmentUniqueCodeRules
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to the entity code will be checked for uniqueness.
        /// </summary>
        public bool CheckUniqueCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the unique code will be set for new goods.
        /// </summary>
        public bool FillUniqueCode { get; set; }

        #endregion Properties
    }
}