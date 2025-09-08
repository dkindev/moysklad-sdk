using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Client.Json;
using Newtonsoft.Json;

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
                    try
                    {
                        return await JsonSerializerHelper
                            .ReadFromStreamAsync(stream, type)
                            .ConfigureAwait(false);
                    }
                    catch (JsonException e)
                    {
                        throw new ApiException($"Error when deserializing HTTP response content. {e.Message}", e);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Creates the <see cref="ApiException"/> from <see cref="HttpResponseMessage"/> object.
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/>.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="settings">The <see cref="JsonSerializerSettings"/>.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <returns>The <see cref="Task"/> containing the instance of <see cref="ApiException"/> type.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="response"/> is null.</exception>
        public static async Task<ApiException> ToApiExceptionAsync(this HttpResponseMessage response, string message, Exception innerException = null)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            var errorMessage = new StringBuilder();
            var status = (int)response.StatusCode;

            errorMessage
                .AppendFormat("{0} HTTP status code - {1}.", message, status.ToString())
                .AppendLine();

            var errorsResponse = await response
                .DeserializeAsync(typeof(ApiErrorsResponse), settings)
                .ConfigureAwait(false) as ApiErrorsResponse;
            if (errorsResponse?.Errors?.Any() == true)
            {
                for (var i = 0; i < errorsResponse.Errors.Length; i++)
                {
                    errorMessage
                        .AppendFormat("\tError {0}:", i.ToString())
                        .AppendLine();

                    if (errorsResponse.Errors[i].Code.HasValue)
                    {
                        errorMessage
                            .AppendFormat("\t\tCode: {0}:", errorsResponse.Errors[i].Code.ToString())
                            .AppendLine();
                    }

                    if (!string.IsNullOrWhiteSpace(errorsResponse.Errors[i].Error))
                    {
                        errorMessage
                            .AppendFormat("\t\tDescription: {0}:", errorsResponse.Errors[i].Error)
                            .AppendLine();
                    }

                    if (!string.IsNullOrWhiteSpace(errorsResponse.Errors[i].MoreInfo))
                    {
                        errorMessage
                            .AppendFormat("\t\tMore info: {0}:", errorsResponse.Errors[i].MoreInfo)
                            .AppendLine();
                    }

                    if (i != errorsResponse.Errors.Length - 1)
                        errorMessage.AppendLine();
                }
            }

            return new ApiException(
                status,
                errorMessage.ToString(),
                response.Headers.ToDictionary(),
                errorsResponse?.Errors,
                innerException
            );
        }

        #endregion Methods
    }
}