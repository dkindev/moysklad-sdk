using System;
using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the <see cref="ProfitReportItem"/> endpoint.
    /// </summary>
    public class ProfitReportApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ProfitReportApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public ProfitReportApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/report/profit", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the profit report by counterparty.
        /// </summary>
        /// <param name="buildQuery">The action to build the query.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="ProfitByCounterpartyReportItem"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<ProfitByCounterpartyReportItem>>> GetByCounterpartyAsync(Action<ReportProfitApiParameterBuilder> buildQuery = null)
        {
            return GetReportAsync<ProfitByCounterpartyReportItem>("/bycounterparty", buildQuery);
        }

        /// <summary>
        /// Gets the profit report by employee.
        /// </summary>
        /// <param name="buildQuery">The action to build the query.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="ProfitByEmployeeReportItem"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<ProfitByEmployeeReportItem>>> GetByEmployeeAsync(Action<ReportProfitApiParameterBuilder> buildQuery = null)
        {
            return GetReportAsync<ProfitByEmployeeReportItem>("/byemployee", buildQuery);
        }

        /// <summary>
        /// Gets the profit report by product.
        /// </summary>
        /// <param name="buildQuery">The action to build the query.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="ProfitByAssortmentReportItem"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<ProfitByAssortmentReportItem>>> GetByProductAsync(Action<ReportProfitApiParameterBuilder> buildQuery = null)
        {
            return GetReportAsync<ProfitByAssortmentReportItem>("/byproduct", buildQuery);
        }

        /// <summary>
        /// Gets the profit report by sales channel.
        /// </summary>
        /// <param name="buildQuery">The action to build the query.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="ProfitBySalesChannelReportItem"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<ProfitBySalesChannelReportItem>>> GetBySalesChannelAsync(Action<ReportProfitApiParameterBuilder> buildQuery = null)
        {
            return GetReportAsync<ProfitBySalesChannelReportItem>("/bysaleschannel", buildQuery);
        }

        /// <summary>
        /// Gets the profit report by variant.
        /// </summary>
        /// <param name="buildQuery">The action to build the query.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="ProfitByAssortmentReportItem"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<ProfitByAssortmentReportItem>>> GetByVariantAsync(Action<ReportProfitApiParameterBuilder> buildQuery = null)
        {
            return GetReportAsync<ProfitByAssortmentReportItem>("/byvariant", buildQuery);
        }

        #endregion Methods

        #region Utilities

        private async Task<ApiResponse<EntitiesResponse<TReport>>> GetReportAsync<TReport>(string relativePath, Action<ReportProfitApiParameterBuilder> buildQuery = null)
        {
            return await CallAsync<EntitiesResponse<TReport>>(new RequestContext($"{Path}{relativePath}", HttpMethod.Get).WithQuery(buildQuery))
                .ConfigureAwait(false);
        }

        #endregion Utilities
    }
}