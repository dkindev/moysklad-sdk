using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents a API to interact with the <typeparamref name="TEntity"/> endpoint.
    /// </summary>
    /// <typeparam name="TEntity">The type of the meta entity.</typeparam>
    /// <typeparam name="TEntityBuilder">The type of the <see cref="ApiParameterBuilder"/> to get single entity.</typeparam>
    /// <typeparam name="TEntitiesBuilder">The type of the <see cref="ApiParameterBuilder"/> to get list of the entity.</typeparam>
    public abstract class EntityApiAccessor<TEntity, TEntityBuilder, TEntitiesBuilder> : ApiAccessor
        where TEntity : MetaEntity
        where TEntityBuilder : ApiParameterBuilder
        where TEntitiesBuilder : ApiParameterBuilder
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="EntityApiAccessor{TEntity, TSingleBuilder, TListBuilder}" /> class
        /// with the API endpoint relative path, the HTTP client and the MoySklad credentials (optional).
        /// </summary>
        /// <param name="relativePath">The API endpoint relative path.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public EntityApiAccessor(string relativePath, HttpClient httpClient, MoySkladCredentials credentials = null)
            : base(relativePath, httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Creates the <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> to create.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the created <typeparamref name="TEntity"/>.</returns>
        public virtual async Task<ApiResponse<TEntity>> CreateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var requestContext = new RequestContext(HttpMethod.Post)
                .WithBody(entity);

            return await CallAsync<TEntity>(requestContext).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates or updates the <typeparamref name="TEntity"/>'s.
        /// </summary>
        /// <param name="entities">The <typeparamref name="TEntity"/>'s to create or update.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the array of <typeparamref name="TEntity"/>.</returns>
        public virtual async Task<ApiResponse<TEntity[]>> CreateOrUpdateAsync(TEntity[] entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            var requestContext = new RequestContext(HttpMethod.Post)
                .WithBody(entities)
                .WithApiExceptionFactory(CreateApiExceptionWithBulkOfErrorsAsync);

            return await CallAsync<TEntity[]>(requestContext).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes the <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> to delete.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual async Task<ApiResponse> DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var id = entity.GetId();
            if (!id.HasValue)
                throw new ApiException(400, "The entity ID cannot be null.");

            return await DeleteAsync(id.Value).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes the <typeparamref name="TEntity"/>'s.
        /// </summary>
        /// <param name="entities">The <typeparamref name="TEntity"/>'s to delete.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual async Task<ApiResponse> DeleteAsync(TEntity[] entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            var requestContext = new RequestContext($"{Path}/delete", HttpMethod.Post)
                .WithBody(entities)
                .WithApiExceptionFactory(CreateApiExceptionWithBulkOfErrorsAsync);

            return await CallAsync<TEntity>(requestContext).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes the <typeparamref name="TEntity"/> by specified ID.
        /// </summary>
        /// <param name="id">The <typeparamref name="TEntity"/> ID.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(Guid id)
        {
            return CallAsync(new RequestContext($"{Path}/{id}", HttpMethod.Delete));
        }

        /// <summary>
        /// Gets the list of <typeparamref name="TEntity"/> by query (optional).
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <typeparamref name="TEntity"/>.</returns>
        public virtual async Task<ApiResponse<EntitiesResponse<TEntity>>> GetAllAsync(TEntitiesBuilder query = null)
        {
            var requestContext = new RequestContext();

            if (query != null)
                requestContext.WithQuery(query.Build());

            return await CallAsync<EntitiesResponse<TEntity>>(requestContext).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the <typeparamref name="TEntity"/> by ID and query (optional).
        /// </summary>
        /// <param name="id">The entity ID.</param>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the <typeparamref name="TEntity"/>.</returns>
        public virtual async Task<ApiResponse<TEntity>> GetAsync(Guid id, TEntityBuilder query = null)
        {
            var requestContext = new RequestContext($"{Path}/{id}");

            if (query != null)
                requestContext.WithQuery(query.Build());

            return await CallAsync<TEntity>(requestContext).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> to update.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the updated <typeparamref name="TEntity"/>.</returns>
        public virtual async Task<ApiResponse<TEntity>> UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var id = entity.GetId();
            if (!id.HasValue)
                throw new ApiException(400, "The entity ID cannot be null.");

            var requestContext = new RequestContext($"{Path}/{id}", HttpMethod.Put)
                .WithBody(entity);

            return await CallAsync<TEntity>(requestContext).ConfigureAwait(false);
        }

        #endregion Methods

        #region Utilities

        /// <summary>
        /// Creates the <see cref="ApiException"/> with bulk of <see cref="ApiErrorsResponse"/>.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="response">The <see cref="HttpResponseMessage"/>.</param>
        /// <param name="exception">The inner exception.</param>
        /// <returns>The <see cref="Task"/> containing the instance of <see cref="ApiException"/> type.</returns>
        protected internal async Task<ApiException> CreateApiExceptionWithBulkOfErrorsAsync(string message, HttpResponseMessage response, HttpRequestException exception)
        {
            if (response == null)
                return new ApiException(message, exception);

            var errorsResponse = await response
                .DeserializeAsync(typeof(ApiErrorsResponse[]))
                .ConfigureAwait(false) as ApiErrorsResponse[];

            var errors = new List<ApiError>();
            foreach (var errorResponse in errorsResponse)
            {
                if (errorResponse == null || errorResponse.Errors == null)
                    continue;

                errors.AddRange(errorResponse.Errors);
            }

            return new ApiException(
                (int)response.StatusCode,
                message,
                response.Headers.ToDictionary(),
                errors.ToArray(),
                exception
            );
        }

        #endregion Utilities
    }
}