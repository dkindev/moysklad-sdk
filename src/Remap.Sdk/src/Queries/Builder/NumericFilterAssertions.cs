using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for numeric property.
    /// </summary>
    /// <typeparam name="T">The type of the property.</typeparam>
    public class NumericFilterAssertions<T> : FilterAssertions where T : struct
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="NumericFilterAssertions{T}" /> class
        /// with the property expression and the filters.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="filters">The filters.</param>
        internal NumericFilterAssertions(LambdaExpression propertyExpression, List<FilterItem> filters)
            : base(propertyExpression, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a property should has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="OrConstraint{NumericFilterAssertions}" /> to add the next filter value.</returns>
        public OrConstraint<NumericFilterAssertions<T>> Be(T value)
        {
            AddFilter(value.ToString(), "=", new[] { "=" });
            return new OrConstraint<NumericFilterAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a property should be greater or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="AndConstraint{NumericFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<NumericFilterAssertions<T>> BeGreaterOrEqualTo(T value)
        {
            AddFilter(value.ToString(), ">=", new[] { "<=", "<", ">" });
            return new AndConstraint<NumericFilterAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a property should be greater than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="AndConstraint{NumericFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<NumericFilterAssertions<T>> BeGreaterThan(T value)
        {
            AddFilter(value.ToString(), ">", new[] { "<", "<=", ">=" });
            return new AndConstraint<NumericFilterAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a property should be less or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="AndConstraint{NumericFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<NumericFilterAssertions<T>> BeLessOrEqualTo(T value)
        {
            AddFilter(value.ToString(), "<=", new[] { ">=", "<", ">" });
            return new AndConstraint<NumericFilterAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a property should be less than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="AndConstraint{NumericFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<NumericFilterAssertions<T>> BeLessThan(T value)
        {
            AddFilter(value.ToString(), "<", new[] { ">", "<=", ">=" });
            return new AndConstraint<NumericFilterAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a property should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="AndConstraint{NumericFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<NumericFilterAssertions<T>> NotBe(T value)
        {
            AddFilter(value.ToString(), "!=", new[] { "!=" });
            return new AndConstraint<NumericFilterAssertions<T>>(this);
        }

        #endregion Methods
    }
}