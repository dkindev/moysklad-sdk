using System.Net.Http;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;

namespace Confiti.MoySklad.Remap.Api
{
    /// <inheritdoc/>
    public class ProductApi :
        EntityApiAccessor<Product, ApiParameterBuilder<ProductQuery>, ApiParameterBuilder<ProductsQuery>>,
        IHasMetadataApi<MetadataWithAttributesApi<ProductMetadata, ProductMetadataQuery>>,
        IHasImageApi
    {
        #region Properties

        /// <inheritdoc/>
        public virtual ImageApi Images { get; }

        /// <inheritdoc/>
        public virtual MetadataWithAttributesApi<ProductMetadata, ProductMetadataQuery> Metadata { get; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ProductApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public ProductApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/product", httpClient, credentials)
        {
            Metadata = new MetadataWithAttributesApi<ProductMetadata, ProductMetadataQuery>(Path, httpClient, credentials);
            Images = new ImageApi(Path, httpClient, credentials);
        }

        #endregion Ctor
    }
}