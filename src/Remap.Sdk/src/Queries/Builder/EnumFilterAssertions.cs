using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confiti.MoySklad.Remap.Extensions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for <see cref="Enum"/> property.
    /// </summary>
    public class EnumFilterAssertions<T> : FilterAssertions where T : Enum
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="EnumFilterAssertions{T}" /> class
        /// with the property expression and the filters.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="filters">The filters.</param>
        internal EnumFilterAssertions(LambdaExpression propertyExpression, List<FilterItem> filters)
            : base(propertyExpression, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a property should has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="OrConstraint{EnumFilterAssertions}" /> to add the next filter value.</returns>
        public OrConstraint<EnumFilterAssertions<T>> Be(T value)
        {
            AddFilter(value.GetParameterName(), "=", new[] { "=" });
            return new OrConstraint<EnumFilterAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a property should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="AndConstraint{EnumFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<EnumFilterAssertions<T>> NotBe(T value)
        {
            AddFilter(value.GetParameterName(), "!=", new[] { "!=" });
            return new AndConstraint<EnumFilterAssertions<T>>(this);
        }

        #endregion Methods
    }
}