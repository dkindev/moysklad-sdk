using System;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an query for list of <see cref="Product"/>.
    /// See also: https://dev.moysklad.ru/doc/api/remap/1.2/dictionaries/#suschnosti-towar.
    /// </summary>
    public class ProductsQuery : ProductQuery
    {
        #region Methods

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is archived.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("archived")]
        public bool Archived { get; set; }

        /// <summary>
        /// Gets or sets the article.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("article")]
        public string Article { get; set; }

        /// <summary>
        /// Gets or sets the barcode.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [Parameter("barcode")]
        public string Barcode { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the external code.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("externalCode")]
        public string ExternalCode { get; set; }

        /// <summary>
        /// Gets or sets the ID.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity should be tracked with serial number.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(allowContinueConstraint: false)]
        [AllowOrder]
        [Parameter("isSerialTrackable")]
        public bool IsSerialTrackable { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(allowNull: false)]
        [AllowOrder]
        [Parameter("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the path name.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("pathName")]
        public string PathName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is shared.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(allowContinueConstraint: false)]
        [AllowOrder]
        [Parameter("shared")]
        public bool Shared { get; set; }

        /// <summary>
        /// Gets or sets the synchronization id.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(overriddenOperators: new[] { "=", "!=" })]
        [Parameter("syncId")]
        public string SyncId { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("updated")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets the volume.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("volume")]
        public double Volume { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("weight")]
        public double Weight { get; set; }

        #endregion Methods
    }
}