using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the <see cref="ReportProfit"/> endpoint.
    /// </summary>
    public class ReportProfitApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ReportProfitApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public ReportProfitApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/report/profit", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the profit report by counterparty.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="ReportProfitByCounterparty"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<ReportProfitByCounterparty>>> GetByCounterpartyAsync(ApiParameterBuilder query = null)
        {
            return GetReportAsync<ReportProfitByCounterparty>("bycounterparty", query);
        }

        /// <summary>
        /// Gets the profit report by employee.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="ReportProfitByEmployee"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<ReportProfitByEmployee>>> GetByEmployeeAsync(ApiParameterBuilder query = null)
        {
            return GetReportAsync<ReportProfitByEmployee>("byemployee", query);
        }

        /// <summary>
        /// Gets the profit report by product.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="ReportProfitByProduct"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<ReportProfitByProduct>>> GetByProductAsync(ApiParameterBuilder query = null)
        {
            return GetReportAsync<ReportProfitByProduct>("byproduct", query);
        }

        /// <summary>
        /// Gets the profit report by sales channel.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="ReportProfitBySalesChannel"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<ReportProfitBySalesChannel>>> GetBySalesChannelAsync(ApiParameterBuilder query = null)
        {
            return GetReportAsync<ReportProfitBySalesChannel>("bysaleschannel", query);
        }

        /// <summary>
        /// Gets the profit report by variant.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="ReportProfitByVariant"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<ReportProfitByVariant>>> GetByVariantAsync(ApiParameterBuilder query = null)
        {
            return GetReportAsync<ReportProfitByVariant>("byvariant", query);
        }

        private Task<ApiResponse<EntitiesResponse<TReport>>> GetReportAsync<TReport>(string relativePath, ApiParameterBuilder query = null)
        {
            return CallAsync<EntitiesResponse<TReport>>(new RequestContext($"{Path}/{relativePath}", HttpMethod.Get).WithQuery(query));
        }

        #endregion Methods
    }
}