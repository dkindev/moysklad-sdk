using Newtonsoft.Json.Serialization;
using System.Reflection;

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

        /// <summary>
        /// Creates the <see cref="IValueProvider"/> used by the serializer to get and set values from a member.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>The <see cref="IValueProvider"/> used by the serializer to get and set values from a member.</returns>
        protected override IValueProvider CreateMemberValueProvider(MemberInfo member)
        {
            var innerProvider = base.CreateMemberValueProvider(member);

            if (member.MemberType == MemberTypes.Property)
            {
                var propType = ((PropertyInfo)member).PropertyType;
                if (propType.IsClass && !propType.IsAssignableFrom(typeof(string)))
                {
                    return new EmptyObjectValueProvider(innerProvider);
                }
            }

            return innerProvider;
        }

        #endregion Methods
    }
}