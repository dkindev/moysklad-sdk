using System.Net.Http;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;

namespace Confiti.MoySklad.Remap.Api
{
    /// <inheritdoc/>
    public class CounterpartyApi : EntityApiAccessor<Counterparty, ApiParameterBuilder<CounterpartyQuery>, ApiParameterBuilder<CounterpartiesQuery>>
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="CounterpartyApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public CounterpartyApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/counterparty", httpClient, credentials)
        {
        }

        #endregion Ctor
    }
}