using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for nullable <see cref="Enum"/> property.
    /// </summary>
    public class NullableEnumFilterAssertions<T> : EnumFilterAssertions<T> where T : Enum
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="NullableEnumFilterAssertions{T}" /> class
        /// with the property expression and the filters.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="filters">The filters.</param>
        internal NullableEnumFilterAssertions(LambdaExpression propertyExpression, List<FilterItem> filters)
            : base(propertyExpression, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a property should has the null value.
        /// </summary>
        /// <returns>The <see cref="OrConstraint{NullableEnumFilterAssertions}" /> to add the next filter value.</returns>
        public OrConstraint<NullableEnumFilterAssertions<T>> BeNull()
        {
            AddFilter(null, "=", new[] { "=" });
            return new OrConstraint<NullableEnumFilterAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a property should not has the null value.
        /// </summary>
        /// <returns>The <see cref="AndConstraint{NullableEnumFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<NullableEnumFilterAssertions<T>> NotBeNull()
        {
            AddFilter(null, "!=", new[] { "!=" });
            return new AndConstraint<NullableEnumFilterAssertions<T>>(this);
        }

        #endregion Methods
    }
}