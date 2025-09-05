using System;
using Confiti.MoySklad.Remap.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Confiti.MoySklad.Remap.Client.Json
{
    /// <summary>
    /// Represents an json converter to and from <see cref="Barcode" />.
    /// </summary>
    public class BarcodeConverter : JsonConverter<Barcode>
    {
        #region Methods

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read. If there is no existing value then <c>null</c> will be used.</param>
        /// <param name="hasExistingValue">The existing value has a value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override Barcode ReadJson(JsonReader reader, Type objectType, Barcode existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    return ReadBarcodeObject(reader, serializer);

                case JsonToken.Null:
                    return null;
            }

            throw new JsonSerializationException($"Unexpected token when reading '{nameof(Barcode)}'.");
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, Barcode value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            var barcodeType = JValue.FromObject(value.Type, serializer) as JValue;

            writer.WriteStartObject();
            writer.WritePropertyName(barcodeType.Value.ToString());

            if (string.IsNullOrEmpty(value.Value))
                writer.WriteNull();
            else
                serializer.Serialize(writer, value.Value);

            writer.WriteEndObject();
        }

        #endregion Methods

        #region Utilities

        private Barcode ReadBarcodeObject(JsonReader reader, JsonSerializer serializer)
        {
            Barcode barcode = null;

            var jObject = JObject.Load(reader);
            if (jObject.HasValues && jObject.First is JProperty jBarcode)
            {
                barcode = new Barcode();

                var jBarcodeType = new JValue(jBarcode.Name);
                barcode.Type = jBarcodeType.ToObject<BarcodeType>(serializer);
                barcode.Value = jBarcode.Value.ToObject<string>(serializer);
            }

            return barcode;
        }

        #endregion Utilities
    }
}