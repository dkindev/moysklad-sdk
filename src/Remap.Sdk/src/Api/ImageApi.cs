using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Extensions;
using Confiti.MoySklad.Remap.Queries;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the <see cref="Image"/> endpoint.
    /// </summary>
    public class ImageApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ImageApi" /> class
        /// with the API endpoint relative path, the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="relativePath">The API endpoint relative path.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public ImageApi(string relativePath, HttpClient httpClient, MoySkladCredentials credentials)
            : base(relativePath, httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Downloads the image.
        /// </summary>
        /// <param name="image">The image to download.</param>
        /// <param name="imageType">The image type.</param>
        /// <returns>The <see cref="Task"/> containing the API response with image data.</returns>
        public virtual async Task<ApiResponse<Stream>> DownloadAsync(Image image, ImageType imageType = ImageType.Normal)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            var downloadHref = image.GetDownloadHref(imageType);
            var requestContext = new RequestContext(downloadHref);

            return await CallAsync<Stream>(requestContext).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the images.
        /// </summary>
        /// <param name="entityId">The id to get images of entity.</param>
        /// <param name="buildQuery">The action to build the query.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="Image"/>.</returns>
        public virtual async Task<ApiResponse<EntitiesResponse<Image>>> GetAllAsync(Guid entityId, Action<ApiParameterBuilder> buildQuery = null)
        {
            return await CallAsync<EntitiesResponse<Image>>(new RequestContext($"{Path}/{entityId}/images").WithQuery(buildQuery))
                .ConfigureAwait(false);
        }

        #endregion Methods
    }
}