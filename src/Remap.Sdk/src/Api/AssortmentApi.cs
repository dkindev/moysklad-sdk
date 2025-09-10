using System;
using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the <see cref="Assortment"/> endpoint.
    /// </summary>
    public class AssortmentApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="AssortmentApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public AssortmentApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/assortment", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Deletes the assortment.
        /// </summary>
        /// <param name="entities">The assortment to delete.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual async Task<ApiResponse> DeleteAsync(Assortment[] entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            var requestContext = new RequestContext($"{Path}/delete", HttpMethod.Post)
                .WithBody(entities)
                .WithBulkOfErrors();

            return await CallAsync(requestContext).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the assortment.
        /// </summary>
        /// <param name="buildQuery">The action to build the query.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="Assortment"/>.</returns>
        public virtual async Task<ApiResponse<EntitiesResponse<Assortment>>> GetAllAsync(Action<AssortmentApiParameterBuilder> buildQuery = null)
        {
            return await CallAsync<EntitiesResponse<Assortment>>(new RequestContext().WithQuery(buildQuery))
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="AssortmentSettings"/>.</returns>
        public virtual Task<ApiResponse<AssortmentSettings>> GetSettingsAsync()
        {
            return CallAsync<AssortmentSettings>(new RequestContext($"{Path}/settings"));
        }

        /// <summary>
        /// Updates the settings.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with updated <see cref="AssortmentSettings"/>.</returns>
        public virtual Task<ApiResponse<AssortmentSettings>> UpdateSettingsAsync(AssortmentSettings settings)
        {
            return CallAsync<AssortmentSettings>(new RequestContext($"{Path}/settings", HttpMethod.Put).WithBody(settings));
        }

        #endregion Methods
    }
}