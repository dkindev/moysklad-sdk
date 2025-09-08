using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the request context to prepare HTTP request.
    /// </summary>
    public class RequestContext
    {
        #region Properties

        /// <summary>
        /// Gets or sets the factory to create <see cref="ApiException"/>.
        /// </summary>
        public Func<string, HttpResponseMessage, HttpRequestException, Task<ApiException>> ApiExceptionFactory { get; set; }

        /// <summary>
        /// Gets or sets the HTTP post body.
        /// </summary>
        public object Body { get; set; }

        /// <summary>
        /// Gets or sets the HTTP content type.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the HTTP request headers.
        /// </summary>
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the HTTP method.
        /// </summary>
        public HttpMethod Method { get; set; }

        /// <summary>
        /// Gets or sets the relative path to the endpoint.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the HTTP request query.
        /// </summary>
        public Dictionary<string, string> Query { get; set; } = new Dictionary<string, string>();

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="RequestContext" /> class.
        /// </summary>
        /// <param name="method">The HTTP method.</param>
        public RequestContext(HttpMethod method = null)
        {
            Method = method ?? HttpMethod.Get;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="RequestContext" /> class
        /// with relative path to the endpoint and HTTP method.
        /// </summary>
        /// <param name="path">The relative path.</param>
        /// <param name="method">The HTTP method.</param>
        public RequestContext(string path, HttpMethod method = null)
            : this(method)
        {
            Path = path;
        }

        #endregion Ctor
    }
}