using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for nullable <see cref="Enum"/> parameter.
    /// </summary>
    public class NullableEnumFilterAssertions<T> : EnumFilterAssertions<T> where T : Enum
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="NullableEnumFilterAssertions{T}" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal NullableEnumFilterAssertions(LambdaExpression parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the null value.
        /// </summary>
        /// <returns>The or constraint.</returns>
        public OrConstraint<NullableEnumFilterAssertions<T>> BeNull()
        {
            AddFilter(null, "=", new[] { "=" });
            return new OrConstraint<NullableEnumFilterAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the null value.
        /// </summary>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NullableEnumFilterAssertions<T>> NotBeNull()
        {
            AddFilter(null, "!=", new[] { "!=" });
            return new AndConstraint<NullableEnumFilterAssertions<T>>(this);
        }

        #endregion Methods
    }
}