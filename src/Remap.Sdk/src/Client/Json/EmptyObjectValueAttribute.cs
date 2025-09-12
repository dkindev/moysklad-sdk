using System;
using System.ComponentModel;

namespace Confiti.MoySklad.Remap.Client.Json
{
    /// <summary>
    /// Represents the attribute to specify empty object value for a property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class EmptyObjectValueAttribute : DefaultValueAttribute
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="EmptyObjectValueAttribute" /> class.
        /// </summary>
        public EmptyObjectValueAttribute() : base(EmptyObjectValueProvider.EMPTY_OBJECT_VALUE)
        {
        }

        #endregion Ctor
    }
}