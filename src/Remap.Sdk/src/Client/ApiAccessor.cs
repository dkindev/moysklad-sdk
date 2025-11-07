using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Confiti.MoySklad.Remap.Client.Json;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents a abstraction to interact with the API endpoint(s).
    /// </summary>
    public abstract class ApiAccessor
    {
        #region Properties

        /// <summary>
        /// Gets the HTTP client.
        /// </summary>
        internal HttpClient Client { get; set; }

        /// <summary>
        /// Gets the MoySklad credentials.
        /// </summary>
        internal MoySkladCredentials Credentials { get; set; }

        /// <summary>
        /// Gets the API endpoint relative path.
        /// </summary>
        internal string Path { get; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ApiAccessor" /> class
        /// with the API endpoint relative path, the HTTP client and the MoySklad credentials (optional).
        /// </summary>
        /// <param name="relativePath">The API endpoint relative path.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public ApiAccessor(string relativePath, HttpClient httpClient, MoySkladCredentials credentials = null)
        {
            Path = relativePath;
            Credentials = credentials;
            Client = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Executes the HTTP request asynchronously.
        /// </summary>
        /// <param name="context">The request context to prepare HTTP request.</param>
        /// <param name="callerName">The caller name.</param>
        /// <typeparam name="TResponse">The type of the response model.</typeparam>
        /// <returns>The <see cref="Task"/> containing the API response with the response model.</returns>
        protected virtual async Task<ApiResponse<TResponse>> CallAsync<TResponse>(RequestContext context, [CallerMemberName] string callerName = "")
            where TResponse : class
        {
            using (var httpResponse = await InternalCallAsync(context, callerName).ConfigureAwait(false))
            {
                return new ApiResponse<TResponse>(
                    (int)httpResponse.StatusCode,
                    httpResponse.Headers.ToDictionary(),
                    await httpResponse
                        .DeserializeAsync(typeof(TResponse))
                        .ConfigureAwait(false) as TResponse
                );
            }
        }

        /// <summary>
        /// Executes the HTTP request asynchronously.
        /// </summary>
        /// <param name="context">The request context to prepare HTTP request.</param>
        /// <param name="callerName">The caller name.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        protected virtual async Task<ApiResponse> CallAsync(RequestContext context, [CallerMemberName] string callerName = "")
        {
            using (var httpResponse = await InternalCallAsync(context, callerName).ConfigureAwait(false))
                return new ApiResponse((int)httpResponse.StatusCode, httpResponse.Headers.ToDictionary());
        }

        #endregion Methods

        #region Utilities

        /// <summary>
        /// Creates the <see cref="HttpRequestMessage"/> by <see cref="RequestContext"/>
        /// </summary>
        /// <param name="context">The request context to prepare HTTP request.</param>
        /// <returns>The <see cref="Task"/> containing <see cref="HttpRequestMessage"/>.</returns>
        /// <exception cref="MoySkladException">Throws if <paramref name="context"/> is null.</exception>
        private async Task<HttpRequestMessage> CreateHttpRequestAsync(RequestContext context)
        {
            var relativeUri = string.IsNullOrEmpty(context.Path) ? Path : context.Path;
            if (context.Query?.Any() == true)
            {
                var parsedQuery = HttpUtility.ParseQueryString(string.Empty);
                foreach (var keyValuePair in context.Query)
                    parsedQuery[keyValuePair.Key] = keyValuePair.Value;

                relativeUri += $"?{parsedQuery}";
            }

            var baseAddress = Client.BaseAddress ?? new Uri(ApiDefaults.DEFAULT_BASE_PATH);
            if (!Uri.TryCreate(baseAddress, relativeUri, out var uri))
                throw new MoySkladException("Cannot create the HTTP request URI.");

            var request = new HttpRequestMessage(context.Method, uri);

            if (Credentials != null)
            {
                if (!string.IsNullOrEmpty(Credentials.AccessToken))
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Credentials.AccessToken);
                else if (!string.IsNullOrEmpty(Credentials.Username) && !string.IsNullOrEmpty(Credentials.Password))
                {
                    var credentialsData = Encoding.UTF8.GetBytes($"{Credentials.Username}:{Credentials.Password}");
                    var convertedCredentialsData = Convert.ToBase64String(credentialsData);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", convertedCredentialsData);
                }
            }

            foreach (var header in context.Headers)
                request.Headers.Add(header.Key, header.Value);

            if (!Client.DefaultRequestHeaders.Contains("UserAgent"))
                request.Headers.Add("UserAgent", ApiDefaults.DEFAULT_USER_AGENT);

            if (!Client.DefaultRequestHeaders.Contains("Accept"))
                request.Headers.Add("Accept", "*/*");

            if (context.Body != null)
            {
                request.Content = new StreamContent(
                    await JsonSerializerHelper
                        .WriteToStreamAsync(context.Body)
                        .ConfigureAwait(false)
                );
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return request;
        }

        /// <summary>
        /// Executes the HTTP request asynchronously.
        /// </summary>
        /// <param name="context">The request context to prepare HTTP request.</param>
        /// <param name="callerName">The caller name.</param>
        /// <returns>The <see cref="Task"/> containing the HTTP response.</returns>
        private async Task<HttpResponseMessage> InternalCallAsync(RequestContext context, [CallerMemberName] string callerName = "")
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            HttpResponseMessage response = null;

            using (var request = await CreateHttpRequestAsync(context).ConfigureAwait(false))
            {
                try
                {
                    response = await Client.SendAsync(request).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException e)
                {
                    var errorMessage = $"Error when calling '{GetType().Name}.{callerName}'. HTTP status code - {(int)response.StatusCode}.";

                    using (response)
                    {
                        MoySkladException apiException = null;

                        if (context.ApiExceptionFactory != null)
                        {
                            apiException = await context
                                .ApiExceptionFactory(errorMessage, response, e)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            apiException = response != null
                                ? await response
                                    .ToApiExceptionAsync(errorMessage, e)
                                    .ConfigureAwait(false)
                                : new MoySkladException(errorMessage, e);
                        }

                        if (apiException != null)
                            throw apiException;
                    }
                }
            }

            return response;
        }

        #endregion Utilities
    }
}