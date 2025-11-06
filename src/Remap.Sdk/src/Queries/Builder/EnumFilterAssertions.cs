using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confiti.MoySklad.Remap.Extensions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for <see cref="Enum"/> parameter.
    /// </summary>
    public class EnumFilterAssertions<T> : FilterAssertions where T : Enum
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="EnumFilterAssertions{T}" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal EnumFilterAssertions(LambdaExpression parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<EnumFilterAssertions<T>> Be(T value)
        {
            AddFilter(value.GetParameterName(), "=", new[] { "=" });
            return new OrConstraint<EnumFilterAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<EnumFilterAssertions<T>> NotBe(T value)
        {
            AddFilter(value.GetParameterName(), "!=", new[] { "!=" });
            return new AndConstraint<EnumFilterAssertions<T>>(this);
        }

        #endregion Methods
    }
}