using System;
using System.ComponentModel;
using Confiti.MoySklad.Remap.Client.Json;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an product folder.
    /// </summary>
    public class ProductFolder : MetaEntity
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ProductFolder" /> class.
        /// </summary>
        public ProductFolder()
            : this(true)
        {
        }

        private ProductFolder(bool createParent)
        {
            if (createParent)
                ParentProductFolder = new ProductFolder(false);
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is archived.
        /// </summary>
        /// <value>The value indicating whether to the entity is archived.</value>
        public bool? Archived { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the effectiveVat vat.
        /// </summary>
        /// <value>The vat.</value>
        public int? EffectiveVat { get; set; }

        /// <summary>
        /// Gets or sets the external code.
        /// </summary>
        /// <value>The external code.</value>
        public string ExternalCode { get; set; }

        /// <summary>
        /// Gets or sets the product folder.
        /// </summary>
        /// <value>The product folder.</value>
        [DefaultValue(EmptyObjectValueProvider.EMPTY_OBJECT_VALUE)]
        [JsonProperty("productFolder", NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ProductFolder ParentProductFolder { get; set; }

        /// <summary>
        /// Gets or sets the path name.
        /// </summary>
        /// <value>The path name.</value>
        public string PathName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is shared.
        /// </summary>
        /// <value>The value indicating whether to the entity is shared.</value>
        public bool? Shared { get; set; }

        /// <summary>
        /// Gets or sets the product tax system.
        /// </summary>
        /// <value>The product tax system.</value>
        public ProductTaxSystem? TaxSystem { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// </summary>
        /// <value>The date when the entity has been updated.</value>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Gets or sets the vat.
        /// </summary>
        /// <value>The vat.</value>
        public int? Vat { get; set; }

        #endregion Properties
    }
}