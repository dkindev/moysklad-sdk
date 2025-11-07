using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Image"/>.
    /// </summary>
    public static class ImageExtensions
    {
        #region Methods

        /// <summary>
        /// Gets the image download href.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="imageType">The image type.</param>
        /// <returns>The download href.</returns>
        public static string GetDownloadHref(this Image image, ImageType imageType)
        {
            if (image == null)
                throw new System.ArgumentNullException(nameof(image));

            var downloadHref = string.Empty;
            switch (imageType)
            {
                case ImageType.Miniature:
                    {
                        if (image.Miniature == null)
                            throw new MoySkladException(400, $"Parameter '{nameof(image.Miniature)}' is missed.");

                        downloadHref = image.Miniature.DownloadHref;
                        break;
                    }

                case ImageType.Tiny:
                    {
                        if (image.Tiny == null)
                            throw new MoySkladException(400, $"Parameter '{nameof(image.Tiny)}' is missed.");

                        downloadHref = image.Tiny.DownloadHref;
                        break;
                    }

                default:
                    {
                        if (image.Meta == null)
                            throw new MoySkladException(400, $"Parameter '{nameof(image.Meta)}' is missed.");

                        downloadHref = image.Meta.DownloadHref;
                        break;
                    }
            }

            if (string.IsNullOrWhiteSpace(downloadHref))
                throw new MoySkladException(400, $"Parameter '{nameof(downloadHref)}' is missed.");

            return downloadHref;
        }

        #endregion Methods
    }
}