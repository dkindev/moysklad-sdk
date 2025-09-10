using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an address.
    /// </summary>
    public class Address
    {
        #region Properties

        /// <summary>
        /// Gets or sets the addInfo.
        /// </summary>
        public string AddInfo { get; set; }

        /// <summary>
        /// Gets or sets the apartment.
        /// </summary>
        public string Apartment { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Gets or sets the fias code for RU region.
        /// </summary>
        [JsonProperty("fiasCode__ru")]
        public string FiasCode { get; set; }

        /// <summary>
        /// Gets or sets the house.
        /// </summary>
        public string House { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        public string Street { get; set; }

        #endregion Properties
    }
}