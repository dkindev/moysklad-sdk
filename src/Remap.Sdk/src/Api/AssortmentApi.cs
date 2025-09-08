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
        /// Gets the assortment.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="Assortment"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<Assortment>>> GetAllAsync(AssortmentApiParameterBuilder query = null)
        {
            return CallAsync<EntitiesResponse<Assortment>>(new RequestContext().WithQuery(query));
        }

        #endregion Methods
    }
}