using System;
using Confiti.MoySklad.Remap.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Confiti.MoySklad.Remap.Client.Json
{
    /// <inheritdoc/>
    public class DiscountConverter : JsonCreationConverter<Discount>
    {
        #region Methods

        /// <inheritdoc/>
        protected override Discount Create(Type objectType, JObject jObject, JsonSerializer serializer)
        {
            if (jObject.HasValues && jObject["meta"] is JObject jMeta)
            {
                var meta = jMeta.ToObject<Meta>(serializer);
                if (meta != null)
                {
                    switch (meta.Type)
                    {
                        case EntityType.Discount:
                            return new Discount();

                        case EntityType.AccumulationDiscount:
                            return new AccumulationDiscount();

                        case EntityType.PersonalDiscount:
                            return new PersonalDiscount();

                        case EntityType.SpecialPriceDiscount:
                            return new SpecialPriceDiscount();

                        case EntityType.BonusProgram:
                            return new BonusProgram();
                    }
                }
            }

            throw new JsonSerializationException($"Cannot deserialize the JSON object into the specific '{nameof(Discount)}'.");
        }

        #endregion Methods
    }
}