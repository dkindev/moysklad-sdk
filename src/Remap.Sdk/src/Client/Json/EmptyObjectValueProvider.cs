using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json.Serialization;

namespace Confiti.MoySklad.Remap.Client.Json
{
    /// <summary>
    /// This decorates the real the value provider to detect
    /// the empty object (All object members are null).
    /// Used to ignore the property default value specified via <see cref="DefaultValueAttribute"/>
    /// and serialize the null value.
    /// See <![CDATA[https://dev.moysklad.ru/doc/api/remap/1.2/#mojsklad-json-api-obschie-swedeniq-podderzhka-null]]>
    /// </summary>
    internal class EmptyObjectValueProvider : IValueProvider
    {
        internal const string EMPTY_OBJECT_VALUE = "{}";

        #region Fields

        private readonly IValueProvider _innerProvider;

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="EmptyObjectValueProvider" /> class.
        /// </summary>
        /// <param name="innerProvider">The inner value provider.</param>
        public EmptyObjectValueProvider(IValueProvider innerProvider)
        {
            _innerProvider = innerProvider;
        }

        #endregion Ctor

        #region Methods

        /// <inheritdoc/>
        public object GetValue(object target)
        {
            var val = _innerProvider.GetValue(target);
            if (val == null)
                return null;

            if (val.GetType().GetProperties().All(p => p.GetValue(val) == null))
                return EMPTY_OBJECT_VALUE;

            return val;
        }

        /// <inheritdoc/>
        public void SetValue(object target, object value)
        {
            _innerProvider.SetValue(target, value);
        }

        #endregion Methods
    }
}