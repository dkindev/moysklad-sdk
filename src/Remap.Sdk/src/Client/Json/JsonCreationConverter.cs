using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Confiti.MoySklad.Remap.Client.Json
{
    /// <summary>
    /// Represents an JSON converter to create the instance of <typeparamref name="T"/> class.
    /// </summary>
    public abstract class JsonCreationConverter<T> : JsonConverter<T>
    {
        #region Properties

        /// <inheritdoc/>
        public override bool CanWrite => false;

        #endregion Properties

        #region Methods

        /// <inheritdoc/>
        public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            T target = Create(objectType, jObject, serializer);
            serializer.Populate(jObject.CreateReader(), target);

            PostPopulate(target, serializer);

            return target;
        }

        /// <inheritdoc/>
        public override sealed void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
            throw new NotSupportedException($"'{nameof(JsonCreationConverter<T>)}' should only be used while deserializing.");
        }

        /// <summary>
        /// Create an instance of object, based on properties in the JSON object.
        /// </summary>
        /// <param name="objectType">The type of object expected.</param>
        /// <param name="jObject">The contents of JSON object that will be deserialized.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        protected abstract T Create(Type objectType, JObject jObject, JsonSerializer serializer);

        /// <summary>
        /// Called after the target object has been populated with JSON values.
        /// </summary>
        /// <param name="value">The populated object.</param>
        /// <param name="serializer">The calling serializer.</param>
        protected virtual void PostPopulate(T value, JsonSerializer serializer)
        {
        }

        #endregion Methods
    }
}