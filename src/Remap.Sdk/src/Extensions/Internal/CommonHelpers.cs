using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;

namespace Confiti.MoySklad.Remap.Extensions
{
    internal static class CommonHelpers
    {
        /// <summary>
        /// Creates the <see cref="MoySkladException"/> with bulk of <see cref="ApiErrorsResponse"/>.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="response">The <see cref="HttpResponseMessage"/>.</param>
        /// <param name="exception">The inner exception.</param>
        /// <returns>The <see cref="Task"/> containing the instance of <see cref="MoySkladException"/> type.</returns>
        public static async Task<MoySkladException> CreateApiExceptionWithBulkOfErrorsAsync(string message, HttpResponseMessage response, HttpRequestException exception)
        {
            if (response == null)
                return new MoySkladException(message, exception);

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

            var errorsArray = errors.ToArray();

            return new MoySkladException(
                (int)response.StatusCode,
                SerializeErrors(message, errorsArray),
                response.Headers.ToDictionary(),
                errorsArray,
                exception
            );
        }

        /// <summary>
        /// Serializes the error message with <see cref="ApiError"/>'s to string.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="errors">The array of <see cref="ApiError"/>.</param>
        /// <returns>The serialized error message.</returns>
        public static string SerializeErrors(string message, params ApiError[] errors)
        {
            if (errors == null || errors.Length == 0)
                return message;

            var errorMessage = new StringBuilder();

            errorMessage
                .Append(message)
                .AppendLine();

            for (var i = 0; i < errors.Length; i++)
            {
                errorMessage
                    .AppendFormat("\tError {0}:", i.ToString())
                    .AppendLine();

                if (errors[i].Code.HasValue)
                {
                    errorMessage
                        .AppendFormat("\t\tCode: {0}:", errors[i].Code.ToString())
                        .AppendLine();
                }

                if (!string.IsNullOrWhiteSpace(errors[i].Error))
                {
                    errorMessage
                        .AppendFormat("\t\tDescription: {0}:", errors[i].Error)
                        .AppendLine();
                }

                if (!string.IsNullOrWhiteSpace(errors[i].MoreInfo))
                {
                    errorMessage
                        .AppendFormat("\t\tMore info: {0}:", errors[i].MoreInfo)
                        .AppendLine();
                }

                if (i != errors.Length - 1)
                    errorMessage.AppendLine();
            }

            return errorMessage.ToString();
        }
    }
}