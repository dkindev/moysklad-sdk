using System;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an pack (e.g. pack of products).
    /// See also: https://dev.moysklad.ru/doc/api/remap/1.2/dictionaries/#suschnosti-towar-towary-atributy-wlozhennyh-suschnostej-upakowki-towara
    /// </summary>
    public class Pack
    {
        #region Properties

        /// <summary>
        /// Gets or sets the barcodes.
        /// </summary>
        public Barcode[] Barcodes { get; set; }

        /// <summary>
        /// Gets or sets the pack id.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public double? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit of measure.
        /// </summary>
        public Uom Uom { get; set; }

        #endregion Properties
    }
}