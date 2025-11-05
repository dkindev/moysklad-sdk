using System;
using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;
using Remap.Sdk.Entities.Reports;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the stock report endpoint.
    /// </summary>
    public class StockReportApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="StockReportApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public StockReportApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/report/stock", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the report that summarizes data on all products, including all necessary information about each product (price, image, etc.). <para/>
        /// Use this report to get detailed product information or to periodically perform a full synchronization with MoySklad, for example, once a day.
        /// However, this is a rather long and complex query, so it's not recommended for frequent use.
        /// </summary>
        /// <param name="buildQuery">The action to build the query.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="AllStockReportItem"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<AllStockReportItem>>> GetAllAsync(Action<AllStockReportApiParameterBuilder> buildQuery = null)
        {
            return GetReportAsync<EntitiesResponse<AllStockReportItem>, AllStockReportApiParameterBuilder>("/all", buildQuery);
        }

        /// <summary>
        /// Gets the report that displays the stock of document items, on the document date, from the store specified in the document, as well as the cost of document items according to FIFO, taking into account quantity.
        /// <para/>
        /// Available documents:
        /// <list type="bullet">
        ///     <item>Demand</item>
        ///     <item>CustomerOrder</item>
        ///     <item>RetailDemand</item>
        ///     <item>InvoiceIn</item>
        ///     <item>InvoiceOut</item>
        ///     <item>PurchaseOrder</item>
        ///     <item>Supply</item>
        ///     <item>RetailSalesReturn</item>
        ///     <item>PurchaseReturn</item>
        ///     <item>SalesReturn</item>
        /// </list>
        /// </summary>
        /// <param name="operationId">The document ID.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="DocumentStock"/>.</returns>
        public virtual async Task<ApiResponse<EntitiesResponse<DocumentStock>>> GetByOperationAsync(Guid operationId)
        {
            return await CallAsync<EntitiesResponse<DocumentStock>>(
                    new RequestContext($"{Path}/byoperation", HttpMethod.Get)
                        .WithQuery("operation.id", operationId.ToString())
                )
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the report that displays the remaining stock of a product/variant/consignment in each store.
        /// </summary>
        /// <param name="buildQuery">The action to build the query.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="AssortmentStockByStore"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<AssortmentStockByStore>>> GetByStoreAsync(Action<StoreStockReportApiParameterBuilder> buildQuery = null)
        {
            return GetReportAsync<EntitiesResponse<AssortmentStockByStore>, StoreStockReportApiParameterBuilder>("/bystore", buildQuery);
        }

        /// <summary>
        /// Gets the report that displays only the product ID and its inventory balance, reserve, or backorder at the time of the request. <para/>
        /// Endpoints are designed for frequent and quick updates of inventory balances, reserves, and backorders for a large number of products. <para/>
        /// Use this report if you need to monitor the inventory of a large number of products and request data every 5-15 minutes.
        /// </summary>
        /// <param name="buildQuery">The action to build the query.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the array of <see cref="CurrentStockReportItem"/>.</returns>
        public virtual Task<ApiResponse<CurrentStockReportItem[]>> GetCurrentAsync(Action<CurrentStockReportApiParameterBuilder> buildQuery = null)
        {
            return GetReportAsync<CurrentStockReportItem[], CurrentStockReportApiParameterBuilder>("/all/current", buildQuery);
        }

        /// <summary>
        /// Gets the report that displays the remaining stock of a product/variant/consignment in slots for a specific store(s) or for all stores for a specific product(s).
        /// Remaining stock for items stored outside of slots will not be displayed.
        /// </summary>
        /// <param name="buildQuery">The action to build the query.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the array of <see cref="CurrentBySlotStockReportItem"/>.</returns>
        public virtual Task<ApiResponse<CurrentBySlotStockReportItem[]>> GetCurrentBySlotAsync(Action<CurrentStockReportApiParameterBuilder> buildQuery = null)
        {
            return GetReportAsync<CurrentBySlotStockReportItem[], CurrentStockReportApiParameterBuilder>("/byslot/current", buildQuery);
        }

        /// <summary>
        /// Gets the report that displays the remaining stock of a product/variant/consignment for a specific store(s) or for all stores for a specific product(s).
        /// </summary>
        /// <param name="buildQuery">The action to build the query.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the array of <see cref="CurrentByStoreStockReportItem"/>.</returns>
        public virtual Task<ApiResponse<CurrentByStoreStockReportItem[]>> GetCurrentByStoreAsync(Action<CurrenByStoreStockReportApiParameterBuilder> buildQuery = null)
        {
            return GetReportAsync<CurrentByStoreStockReportItem[], CurrenByStoreStockReportApiParameterBuilder>("/bystore/current", buildQuery);
        }

        #endregion Methods

        #region Utilities

        private async Task<ApiResponse<TItem>> GetReportAsync<TItem, TBuilder>(string relativePath, Action<TBuilder> buildQuery = null)
            where TItem : class
            where TBuilder : ApiParameterBuilder, new()
        {
            return await CallAsync<TItem>(new RequestContext($"{Path}{relativePath}", HttpMethod.Get).WithQuery(buildQuery))
                .ConfigureAwait(false);
        }

        #endregion Utilities
    }
}