using System;
using Confiti.MoySklad.Remap.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Confiti.MoySklad.Remap.Client.Json
{
    /// <inheritdoc/>
    public class AbstractProductConverter : JsonCreationConverter<AbstractProduct>
    {
        #region Methods

        /// <inheritdoc/>
        protected override AbstractProduct Create(Type objectType, JObject jObject, JsonSerializer serializer)
        {
            if (jObject.HasValues && jObject["meta"] is JObject jMeta)
            {
                var meta = jMeta.ToObject<Meta>(serializer);
                if (meta != null)
                {
                    switch (meta.Type)
                    {
                        case EntityType.Product:
                            return new Product();

                        case EntityType.Variant:
                            return new Variant();

                        case EntityType.Service:
                            return new Service();

                        case EntityType.Bundle:
                            return new Bundle();
                    }
                }
            }

            throw new JsonSerializationException($"Cannot deserialize the JSON object into the specific '{nameof(AbstractProduct)}'.");
        }

        #endregion Methods
    }
}