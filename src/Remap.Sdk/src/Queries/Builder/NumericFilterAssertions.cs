using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for numeric parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter.</typeparam>
    public class NumericFilterAssertions<T> : FilterAssertions where T : struct
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="NumericFilterAssertions{T}" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal NumericFilterAssertions(LambdaExpression parameter, List<FilterItem> filters)
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
        public OrConstraint<NumericFilterAssertions<T>> Be(T value)
        {
            AddFilter(value.ToString(), "=", new[] { "=" });
            return new OrConstraint<NumericFilterAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NumericFilterAssertions<T>> BeGreaterOrEqualTo(T value)
        {
            AddFilter(value.ToString(), ">=", new[] { "<=", "<", ">" });
            return new AndConstraint<NumericFilterAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NumericFilterAssertions<T>> BeGreaterThan(T value)
        {
            AddFilter(value.ToString(), ">", new[] { "<", "<=", ">=" });
            return new AndConstraint<NumericFilterAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be less or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NumericFilterAssertions<T>> BeLessOrEqualTo(T value)
        {
            AddFilter(value.ToString(), "<=", new[] { ">=", "<", ">" });
            return new AndConstraint<NumericFilterAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be less than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NumericFilterAssertions<T>> BeLessThan(T value)
        {
            AddFilter(value.ToString(), "<", new[] { ">", "<=", ">=" });
            return new AndConstraint<NumericFilterAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NumericFilterAssertions<T>> NotBe(T value)
        {
            AddFilter(value.ToString(), "!=", new[] { "!=" });
            return new AndConstraint<NumericFilterAssertions<T>>(this);
        }

        #endregion Methods
    }
}