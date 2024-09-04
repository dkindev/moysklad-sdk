using System.Collections.Generic;
using System.Linq;

namespace System.Net.Http.Headers
{
    /// <summary>
    /// Extension methods for <see cref="HttpResponseHeaders"/>.
    /// </summary>
    internal static class HttpResponseHeadersExtensions
    {
        #region Methods

        /// <summary>
        /// Creates the <see cref="IDictionary{Name, Value}"/> from <see cref="HttpResponseHeaders"/> object.
        /// </summary>
        /// <param name="headers">The headers.</param>
        /// <returns>The <see cref="IDictionary{Name, Value}"/>.</returns>
        public static Dictionary<string, string> ToDictionary(this HttpResponseHeaders headers)
        {
            return headers?.ToDictionary(nameValues => nameValues.Key, nameValues => string.Join(", ", nameValues.Value));
        }

        #endregion Methods
    }
}