using System;
using Confiti.MoySklad.Remap.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Confiti.MoySklad.Remap.Client.Json
{
    /// <inheritdoc/>
    public class AttributeValueConverter : JsonCreationConverter<AttributeValue>
    {
        #region Methods

        /// <inheritdoc/>
        protected override AttributeValue Create(Type objectType, JObject jObject, JsonSerializer serializer)
        {
            return new AttributeValue();
        }

        /// <inheritdoc/>
        protected override void PostPopulate(AttributeValue attributeValue, JsonSerializer serializer)
        {
            var jToken = attributeValue.Value is JObject
                ? attributeValue.Value as JToken
                : new JValue(attributeValue.Value);

            switch (attributeValue.Type)
            {
                case AttributeType.Long:
                    attributeValue.Value = jToken.ToObject<long>(serializer);
                    break;

                case AttributeType.Time:
                    attributeValue.Value = jToken.ToObject<DateTime>(serializer);
                    break;

                case AttributeType.Double:
                    attributeValue.Value = jToken.ToObject<double>(serializer);
                    break;

                case AttributeType.Boolean:
                    attributeValue.Value = jToken.ToObject<bool>(serializer);
                    break;

                case AttributeType.CustomEntity:
                    attributeValue.Value = jToken.ToObject<CustomEntity>(serializer);
                    break;

                case AttributeType.Counterparty:
                    attributeValue.Value = jToken.ToObject<Counterparty>(serializer);
                    break;

                case AttributeType.Organization:
                    attributeValue.Value = jToken.ToObject<Organization>(serializer);
                    break;

                case AttributeType.Employee:
                    attributeValue.Value = jToken.ToObject<Employee>(serializer);
                    break;

                case AttributeType.Product:
                    attributeValue.Value = jToken.ToObject<Product>(serializer);
                    break;

                case AttributeType.Bundle:
                    attributeValue.Value = jToken.ToObject<Bundle>(serializer);
                    break;

                case AttributeType.Service:
                    attributeValue.Value = jToken.ToObject<Service>(serializer);
                    break;

                case AttributeType.Contract:
                    attributeValue.Value = jToken.ToObject<Contract>(serializer);
                    break;

                case AttributeType.Project:
                    attributeValue.Value = jToken.ToObject<Project>(serializer);
                    break;

                case AttributeType.Store:
                    attributeValue.Value = jToken.ToObject<Store>(serializer);
                    break;

                default:
                    // AttributeType.String
                    // AttributeType.Text
                    // AttributeType.Link
                    // AttributeType.File
                    attributeValue.Value = jToken.ToObject<string>(serializer);
                    break;
            }
        }

        #endregion Methods
    }
}