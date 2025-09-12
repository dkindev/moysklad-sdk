using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;

namespace Remap.Sdk.Queries
{
    /// <summary>
    /// Represents an query for <see cref="Pack"/>.
    /// See also: https://dev.moysklad.ru/doc/api/remap/1.2/dictionaries/#suschnosti-towar-towary-atributy-wlozhennyh-suschnostej-upakowki-towara
    /// </summary>
    public class PacksQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unit of measure.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("uom")]
        public UomQuery Uom { get; set; }

        #endregion Properties
    }
}