using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;

namespace Confiti.MoySklad.Remap.Extensions
{
    internal static class CommonHelpers
    {
        /// <summary>
        /// Creates the <see cref="ApiException"/> with bulk of <see cref="ApiErrorsResponse"/>.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="response">The <see cref="HttpResponseMessage"/>.</param>
        /// <param name="exception">The inner exception.</param>
        /// <returns>The <see cref="Task"/> containing the instance of <see cref="ApiException"/> type.</returns>
        public static async Task<ApiException> CreateApiExceptionWithBulkOfErrorsAsync(string message, HttpResponseMessage response, HttpRequestException exception)
        {
            if (response == null)
                return new ApiException(message, exception);

            var errorsResponse = await response
                .DeserializeAsync(typeof(ApiErrorsResponse[]))
                .ConfigureAwait(false) as ApiErrorsResponse[];

            var errors = new List<ApiError>();
            foreach (var errorResponse in errorsResponse)
            {
                if (errorResponse == null || errorResponse.Errors == null)
                    continue;

                errors.AddRange(errorResponse.Errors);
            }

            return new ApiException(
                (int)response.StatusCode,
                message,
                response.Headers.ToDictionary(),
                errors.ToArray(),
                exception
            );
        }
    }
}