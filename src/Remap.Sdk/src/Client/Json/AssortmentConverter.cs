using System;
using Confiti.MoySklad.Remap.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Confiti.MoySklad.Remap.Client.Json
{
    /// <inheritdoc/>
    public class AssortmentConverter : JsonCreationConverter<Assortment>
    {
        #region Methods

        /// <inheritdoc/>
        protected override Assortment Create(Type objectType, JObject jObject, JsonSerializer serializer)
        {
            var assortment = new Assortment();

            if (jObject.HasValues)
                assortment.Product = jObject.ToObject<AbstractProduct>(serializer);

            return assortment;
        }

        #endregion Methods
    }
}