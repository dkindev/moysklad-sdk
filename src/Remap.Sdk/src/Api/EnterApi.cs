﻿using System.Net.Http;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;

namespace Confiti.MoySklad.Remap.Api
{
    /// <inheritdoc/>
    public class EnterApi : EntityApiAccessor<Enter, ApiParameterBuilder<EnterQuery>, ApiParameterBuilder<EnterQuery>>
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="EnterApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public EnterApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/enter", httpClient, credentials)
        {
        }

        #endregion Ctor
    }
}