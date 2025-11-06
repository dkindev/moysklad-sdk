using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for nullable numeric parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    public class NullableNumericFilterAssertions<T> : NumericFilterAssertions<T> where T : struct
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="NullableNumericFilterAssertions{T}" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal NullableNumericFilterAssertions(LambdaExpression parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the null value.
        /// </summary>
        /// <returns>The or constraint.</returns>
        public OrConstraint<NullableNumericFilterAssertions<T>> BeNull()
        {
            AddFilter(null, "=", new[] { "=" });
            return new OrConstraint<NullableNumericFilterAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the null value.
        /// </summary>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NullableNumericFilterAssertions<T>> NotBeNull()
        {
            AddFilter(null, "!=", new[] { "!=" });
            return new AndConstraint<NullableNumericFilterAssertions<T>>(this);
        }

        #endregion Methods
    }
}