using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for nullable numeric property.
    /// </summary>
    /// <typeparam name="T">The type of the property.</typeparam>
    public class NullableNumericFilterAssertions<T> : NumericFilterAssertions<T> where T : struct
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="NullableNumericFilterAssertions{T}" /> class
        /// with the property expression and the filters.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="filters">The filters.</param>
        internal NullableNumericFilterAssertions(LambdaExpression propertyExpression, List<FilterItem> filters)
            : base(propertyExpression, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a property should has the null value.
        /// </summary>
        /// <returns>The <see cref="OrConstraint{NullableNumericFilterAssertions}" /> to add the next filter value.</returns>
        public OrConstraint<NullableNumericFilterAssertions<T>> BeNull()
        {
            AddFilter(null, "=", new[] { "=" });
            return new OrConstraint<NullableNumericFilterAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a property should not has the null value.
        /// </summary>
        /// <returns>The <see cref="AndConstraint{NullableNumericFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<NullableNumericFilterAssertions<T>> NotBeNull()
        {
            AddFilter(null, "!=", new[] { "!=" });
            return new AndConstraint<NullableNumericFilterAssertions<T>>(this);
        }

        #endregion Methods
    }
}