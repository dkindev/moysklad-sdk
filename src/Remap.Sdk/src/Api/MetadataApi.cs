using System;
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
    public class MetadataApi<TResponse, TQuery> : MetadataApi<TResponse>
        where TResponse : MetaEntity
        where TQuery : class
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
        /// <param name="buildQuery">The action to build the query.</param>
        /// <returns>The <see cref="Task"/> containing the API response with metadata.</returns>
        public virtual async Task<ApiResponse<TResponse>> GetAsync(Action<ApiParameterBuilder<TQuery>> buildQuery)
        {
            return await CallAsync<TResponse>(new RequestContext().WithQuery(buildQuery))
                .ConfigureAwait(false);
        }

        #endregion Methods
    }

    /// <summary>
    /// Represents the API to interact with the <typeparamref name="TResponse"/> endpoint.
    /// </summary>
    /// <typeparam name="TResponse">The metadata type.</typeparam>
    /// <typeparam name="TQuery">The concrete type of the meta entity query.</typeparam>
    public class MetadataWithAttributesApi<TResponse, TQuery> : MetadataApi<TResponse, TQuery>
        where TResponse : MetaEntity
        where TQuery : class
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="MetadataApi{TResponse, TQuery}" /> class
        /// with the API endpoint relative path, the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="relativePath">The API endpoint relative path.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public MetadataWithAttributesApi(string relativePath, HttpClient httpClient, MoySkladCredentials credentials)
            : base(relativePath, httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the attribute by ID.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with metadata.</returns>
        public virtual async Task<ApiResponse<PagedEntities<AttributeDefinition>>> GetAttributeAsync(Guid id)
        {
            return await CallAsync<PagedEntities<AttributeDefinition>>(new RequestContext($"{Path}/attributes/{id}"))
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with metadata.</returns>
        public virtual async Task<ApiResponse<PagedEntities<AttributeDefinition>>> GetAttributesAsync()
        {
            return await CallAsync<PagedEntities<AttributeDefinition>>(new RequestContext($"{Path}/attributes"))
                .ConfigureAwait(false);
        }

        #endregion Methods
    }
}