using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Confiti.MoySklad.Remap.Client.Json
{
    internal static class JsonSerializerHelper
    {
        #region Type fields

        private static readonly int _bufferSize = 1024;

        private static readonly IList<JsonConverter> _defaultConverters = new JsonConverter[]
        {
            new StringEnumConverter(),
            new AbstractProductConverter(),
            new AssortmentConverter(),
            new AttributeValueConverter(),
            new BarcodeConverter(),
            new DiscountConverter(),
            new PaymentDocumentConverter()
        };

        private static readonly JsonSerializerSettings _defaultReadSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            Converters = _defaultConverters
        };

        private static readonly JsonSerializerSettings _defaultWriteSettings = new JsonSerializerSettings
        {
            DateFormatString = ApiDefaults.DEFAULT_DATETIME_FORMAT,
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = DefaultMoySkladContractResolver.Instance,
            Converters = _defaultConverters
        };

        private static readonly UTF8Encoding _utf8EncodingWithoutPreamble = new UTF8Encoding(false);

        #endregion Type fields

        #region Methods

        public static async Task<object> ReadFromStreamAsync(Stream stream, Type type)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (!stream.CanRead)
                return null;

            using (var streamReader = new StreamReader(stream))
            using (var reader = new JsonTextReader(streamReader))
                return await Task.Run(() => JsonSerializer.Create(_defaultReadSettings).Deserialize(reader, type)).ConfigureAwait(false);
        }

        public static async Task<Stream> WriteToStreamAsync(object body)
        {
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            var memStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memStream, _utf8EncodingWithoutPreamble, _bufferSize, leaveOpen: true))
            using (var jsonTextWriter = new JsonTextWriter(streamWriter) { Formatting = Formatting.None })
            {
                JsonSerializer.Create(_defaultWriteSettings).Serialize(jsonTextWriter, body);
                await jsonTextWriter.FlushAsync().ConfigureAwait(false);

                memStream.Seek(0, SeekOrigin.Begin);
            }

            return memStream;
        }

        #endregion Methods
    }
}