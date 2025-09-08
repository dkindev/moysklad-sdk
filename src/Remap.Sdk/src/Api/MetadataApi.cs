using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the <typeparamref name="TResponse"/> endpoint.
    /// </summary>
    /// <typeparam name="TResponse">The metadata type.</typeparam>
    public class MetadataApi<TResponse> : ApiAccessor where TResponse : MetaEntity
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="MetadataApi{TResponse}" /> class
        /// with the API endpoint relative path, the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="relativePath">The API endpoint relative path.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public MetadataApi(string relativePath, HttpClient httpClient, MoySkladCredentials credentials)
            : base($"{relativePath}/metadata", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with metadata.</returns>
        public virtual Task<ApiResponse<TResponse>> GetAsync() => CallAsync<TResponse>(new RequestContext());

        #endregion Methods
    }

    /// <summary>
    /// Represents the API to interact with the <typeparamref name="TResponse"/> endpoint.
    /// </summary>
    /// <typeparam name="TResponse">The metadata type.</typeparam>
    /// <typeparam name="TQuery">The concrete type of the meta entity query.</typeparam>
    public class MetadataApi<TResponse, TQuery> : MetadataApi<TResponse> where TResponse : MetaEntity where TQuery : class
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="MetadataApi{TResponse, TQuery}" /> class
        /// with the API endpoint relative path, the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="relativePath">The API endpoint relative path.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public MetadataApi(string relativePath, HttpClient httpClient, MoySkladCredentials credentials)
            : base(relativePath, httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        /// <param name="query">The meta entity query.</param>
        /// <returns>The <see cref="Task"/> containing the API response with metadata.</returns>
        public virtual Task<ApiResponse<TResponse>> GetAsync(ApiParameterBuilder<TQuery> query)
        {
            return CallAsync<TResponse>(new RequestContext().WithQuery(query));
        }

        #endregion Methods
    }
}