using Confiti.MoySklad.Remap.Client.Json;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an good (e.g. product, service and bundle).
    /// </summary>
    public abstract class Goods : AbstractProduct, ISynchronizationSupported
    {
        #region Properties

        /// <summary>
        /// Gets or sets the attribute values.
        /// </summary>
        public AttributeValue[] Attributes { get; set; }

        /// <summary>
        /// Gets or sets the effective VAT.
        /// </summary>
        public int? EffectiveVat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the effective VAT is enabled.
        /// </summary>
        public bool? EffectiveVatEnabled { get; set; }

        /// <summary>
        /// Gets or sets the files.
        /// </summary>
        [EmptyObjectValue]
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PagedEntities<File> Files { get; set; } = new PagedEntities<File>();

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        [EmptyObjectValue]
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Employee Owner { get; set; } = new Employee();

        /// <summary>
        /// Gets or sets the path name.
        /// </summary>
        public string PathName { get; set; }

        /// <summary>
        /// Gets or sets the product folder.
        /// </summary>
        [EmptyObjectValue]
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ProductFolder ProductFolder { get; set; } = new ProductFolder(false);

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is shared.
        /// </summary>
        public bool? Shared { get; set; }

        /// <summary>
        /// Gets or sets the synchronization id.
        /// </summary>
        public string SyncId { get; set; }

        /// <summary>
        /// Gets or sets the product tax system.
        /// </summary>
        public ProductTaxSystem? TaxSystem { get; set; }

        /// <summary>
        /// Gets or sets the unit of measure.
        /// </summary>
        public Uom Uom { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the VAT from the parent folder is used.
        /// </summary>
        public bool? UseParentVat { get; set; }

        /// <summary>
        /// Gets or sets the VAT.
        /// </summary>
        public int? Vat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the VAT is enabled.
        /// </summary>
        public bool? VatEnabled { get; set; }

        #endregion Properties
    }
}