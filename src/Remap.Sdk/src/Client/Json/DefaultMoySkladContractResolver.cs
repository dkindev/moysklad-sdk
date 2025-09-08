using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json.Serialization;

namespace Confiti.MoySklad.Remap.Client.Json
{
    /// <summary>
    /// Provides a default implementation to resolve the <see cref="JsonContract"/>.
    /// </summary>
    public class DefaultMoySkladContractResolver : CamelCasePropertyNamesContractResolver
    {
        #region Properties

        internal static DefaultMoySkladContractResolver Instance { get; } = new DefaultMoySkladContractResolver();

        #endregion Properties

        #region Methods

        /// <inheritdoc/>
        protected override IValueProvider CreateMemberValueProvider(MemberInfo member)
        {
            var innerProvider = base.CreateMemberValueProvider(member);

            if (member.MemberType == MemberTypes.Property)
            {
                var propType = ((PropertyInfo)member).PropertyType;
                if (propType.IsClass
                        && !propType.IsAssignableFrom(typeof(string))
                            && member.IsDefined(typeof(DefaultValueAttribute)))
                {
                    return new EmptyObjectValueProvider(innerProvider);
                }
            }

            return innerProvider;
        }

        #endregion Methods
    }
}