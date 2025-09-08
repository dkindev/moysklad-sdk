using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Extension methods for <see cref="RequestContext"/>.
    /// </summary>
    public static class RequestContextExtensions
    {
        #region Methods

        /// <summary>
        /// Adds the accept header to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="acceptHeader">The accept header value.</param>
        /// <returns>The request context.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="context"/> is null.</exception>
        public static RequestContext WithAccept(this RequestContext context, string acceptHeader)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.Headers["Accept"] = acceptHeader;
            return context;
        }

        /// <summary>
        /// Adds the factory to create <see cref="ApiException"/> to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="factory">The factory to create <see cref="ApiException"/>.</param>
        /// <returns>The request context.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="context"/> is null.</exception>
        public static RequestContext WithApiExceptionFactory(this RequestContext context, Func<string, HttpResponseMessage, HttpRequestException, Task<ApiException>> factory)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.ApiExceptionFactory = factory;
            return context;
        }

        /// <summary>
        /// Adds the body to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="body">The body.</param>
        /// <returns>The request context.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="context"/> is null.</exception>
        public static RequestContext WithBody(this RequestContext context, object body)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.Body = body;
            return context;
        }

        /// <summary>
        /// Adds the content type to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="contentType">The content type.</param>
        /// <returns>The request context.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="context"/> is null.</exception>
        public static RequestContext WithContentType(this RequestContext context, string contentType)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.ContentType = contentType;
            return context;
        }

        /// <summary>
        /// Adds the header to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="name">The header name.</param>
        /// <param name="value">The header value.</param>
        /// <returns>The request context.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="context"/> is null.</exception>
        public static RequestContext WithHeader(this RequestContext context, string name, string value)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.Headers[name] = value;
            return context;
        }

        /// <summary>
        /// Adds the headers to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="headers">The headers.</param>
        /// <returns>The request context.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="context"/> is null.</exception>
        public static RequestContext WithHeaders(this RequestContext context, Dictionary<string, string> headers)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            foreach (var header in headers)
                context.Headers[header.Key] = header.Value;
            return context;
        }

        /// <summary>
        /// Adds the HTTP method to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="method">The HTTP method.</param>
        /// <returns>The request context.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="context"/> is null.</exception>
        public static RequestContext WithMethod(this RequestContext context, HttpMethod method)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.Method = method;
            return context;
        }

        /// <summary>
        /// Adds the relative path to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="path">The relative path to the endpoint.</param>
        /// <returns>The request context.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="context"/> is null.</exception>
        public static RequestContext WithPath(this RequestContext context, string path)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.Path = path;
            return context;
        }

        /// <summary>
        /// Adds the query to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="query">The query.</param>
        /// <returns>The request context.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="context"/> is null.</exception>
        public static RequestContext WithQuery(this RequestContext context, Dictionary<string, string> query)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            foreach (var parameter in query)
                context.Query[parameter.Key] = parameter.Value;
            return context;
        }

        /// <summary>
        /// Adds the query parameter to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="name">The query parameter name.</param>
        /// <param name="value">The query parameter value.</param>
        /// <returns>The request context.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="context"/> is null.</exception>
        public static RequestContext WithQuery(this RequestContext context, string name, string value)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.Query[name] = value;
            return context;
        }

        #endregion Methods
    }
}