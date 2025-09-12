using System;
using Confiti.MoySklad.Remap.Client.Json;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an product.
    /// </summary>
    public class Product : PhysicalGoods
    {
        #region Properties

        /// <summary>
        /// Gets or sets the alcoholic product information.
        /// </summary>
        public Alcoholic Alcoholic { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is serial trackable.
        /// </summary>
        public bool? IsSerialTrackable { get; set; }

        /// <summary>
        /// Gets or sets the minimum balance.
        /// </summary>
        [Obsolete]
        public double? MinimumBalance { get; set; }

        /// <summary>
        /// Gets or sets the packs.
        /// </summary>
        public Pack[] Packs { get; set; }

        /// <summary>
        /// Gets or sets the code of the type of nomenclature classification of medical personal protective equipment.
        /// </summary>
        public string PpeType { get; set; }

        /// <summary>
        /// Gets or sets the supplier.
        /// </summary>
        [EmptyObjectValue]
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Counterparty Supplier { get; set; } = new Counterparty();

        /// <summary>
        /// Gets or sets the serial numbers.
        /// </summary>
        public string[] Things { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the product is tobacco.
        /// </summary>
        public bool? Tobacco { get; set; }

        /// <summary>
        /// Gets or sets the variants count.
        /// </summary>
        public int? VariantsCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is weighed.
        /// </summary>
        public bool? Weighed { get; set; }

        #endregion Properties
    }
}