using Confiti.MoySklad.Remap.Client.Json;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an bundle.
    /// </summary>
    public class PhysicalGoods : Goods
    {
        #region Properties

        /// <summary>
        /// Gets or sets the article.
        /// </summary>
        public string Article { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        [EmptyObjectValue]
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Country Country { get; set; } = new Country();

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        [EmptyObjectValue]
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PagedEntities<Image> Images { get; set; } = new PagedEntities<Image>();

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is partial disposable.
        /// </summary>
        public bool? PartialDisposal { get; set; }

        /// <summary>
        /// Gets or sets the payment item type.
        /// </summary>
        public PhysicalGoodsPaymentItemType? PaymentItemType { get; set; }

        /// <summary>
        /// Gets or sets the tnved.
        /// </summary>
        public string Tnved { get; set; }

        /// <summary>
        /// Gets or sets the tracking type.
        /// </summary>
        public TrackingType? TrackingType { get; set; }

        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        public double? Volume { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        public double? Weight { get; set; }

        #endregion Properties
    }
}