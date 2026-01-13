using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the token endpoint.
    /// </summary>
    public class TokenApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="TokenApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public TokenApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/security/token", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the access token by credentials (if null, the <see cref="MoySkladApi.Credentials"/> are used).
        /// </summary>
        /// <param name="credentials">The credentials, if value is null, default credentials ​​are used (<see cref="MoySkladApi.Credentials"/>).</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetTokenResponse"/>.</returns>
        public virtual async Task<ApiResponse<GetTokenResponse>> GetAsync(MoySkladCredentials credentials = null)
        {
            if (credentials != null)
                CheckBasicAuthCredentials(credentials);
            else
            {
                if (Credentials == null)
                    throw new MoySkladException("No credentials provided.");

                CheckBasicAuthCredentials(Credentials);
            }

            return await CallAsync<GetTokenResponse>(new RequestContext(HttpMethod.Post).WithCredentials(credentials))
                .ConfigureAwait(false);
        }

        #endregion Methods

        #region Utilities

        private void CheckBasicAuthCredentials(MoySkladCredentials credentials)
        {
            if (string.IsNullOrEmpty(credentials.Username))
                throw new MoySkladException($"{nameof(credentials.Username)} should not be null or empty.");

            if (string.IsNullOrEmpty(credentials.Password))
                throw new MoySkladException($"{nameof(credentials.Password)} should not be null or empty.");
        }

        #endregion Utilities
    }
}