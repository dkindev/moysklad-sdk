using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Client.Json;
using Confiti.MoySklad.Remap.Extensions;

namespace System.Net.Http
{
    /// <summary>
    /// Extension methods for <see cref="HttpResponseMessage"/>.
    /// </summary>
    internal static class HttpResponseMessageExtensions
    {
        #region Methods

        /// <summary>
        /// Deserializes the <see cref="HttpResponseMessage"/> into a proper object.
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/>.</param>
        /// <param name="type">The destination type.</param>
        /// <returns>The <see cref="Task"/> containing the object or null.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="response"/> or <paramref name="type"/> is null.</exception>
        /// <exception cref="ApiException">Throws if deserialization failed with an error.</exception>
        public static async Task<object> DeserializeAsync(this HttpResponseMessage response, Type type)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            if (type == null)
                throw new ArgumentNullException(nameof(type));

            using (var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
            {
                if (type == typeof(Stream))
                {
                    var memStream = new MemoryStream();
                    await stream.CopyToAsync(memStream).ConfigureAwait(false);

                    return memStream;
                }

                if (response.Content.Headers.ContentType.MediaType.Contains("application/json"))
                {
                    return await JsonSerializerHelper
                        .ReadFromStreamAsync(stream, type)
                        .ConfigureAwait(false);
                }
            }

            return null;
        }

        /// <summary>
        /// Creates the <see cref="ApiException"/> from <see cref="HttpResponseMessage"/> object.
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/>.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <returns>The <see cref="Task"/> containing the instance of <see cref="ApiException"/> type.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="response"/> is null.</exception>
        public static async Task<ApiException> ToApiExceptionAsync(this HttpResponseMessage response, string message, Exception innerException = null)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            var errorsResponse = await response
                .DeserializeAsync(typeof(ApiErrorsResponse))
                .ConfigureAwait(false) as ApiErrorsResponse;

            return new ApiException(
                (int)response.StatusCode,
                CommonHelpers.SerializeErrors(message, errorsResponse?.Errors),
                response.Headers.ToDictionary(),
                errorsResponse?.Errors,
                innerException
            );
        }

        #endregion Methods
    }
}