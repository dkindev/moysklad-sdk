using System;
using Confiti.MoySklad.Remap.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Confiti.MoySklad.Remap.Client.Json
{
    /// <inheritdoc/>
    public class PaymentDocumentConverter : JsonCreationConverter<PaymentDocument>
    {
        #region Methods

        /// <inheritdoc/>
        protected override PaymentDocument Create(Type objectType, JObject jObject, JsonSerializer serializer)
        {
            if (jObject.HasValues && jObject["meta"] is JObject jMeta)
            {
                var meta = jMeta.ToObject<Meta>(serializer);
                if (meta != null)
                {
                    switch (meta.Type)
                    {
                        case EntityType.CashIn:
                            return new CashIn();

                        case EntityType.CashOut:
                            return new CashOut();

                        case EntityType.PaymentIn:
                            return new PaymentIn();

                        case EntityType.PaymentOut:
                            return new PaymentOut();
                    }
                }
            }

            throw new JsonSerializationException($"Cannot deserialize the JSON object into the specific '{nameof(PaymentDocument)}'.");
        }

        #endregion Methods
    }
}