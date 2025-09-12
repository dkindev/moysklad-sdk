using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an query for <see cref="ProductFolder"/>.
    /// </summary>
    public class ProductFolderQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the path name.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("pathName")]
        public string PathName { get; set; }

        #endregion Properties
    }
}