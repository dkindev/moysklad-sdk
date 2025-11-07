using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for <see cref="string"/> property.
    /// </summary>
    public class StringFilterAssertions : FilterAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="StringFilterAssertions" /> class
        /// with the property expression and the filters.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="filters">The filters.</param>
        internal StringFilterAssertions(LambdaExpression propertyExpression, List<FilterItem> filters)
            : base(propertyExpression, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a property should has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="OrConstraint{StringFilterAssertions}" /> to add the next filter value.</returns>
        public OrConstraint<StringFilterAssertions> Be(string value)
        {
            AddFilter(value, "=", new[] { "=" });
            return new OrConstraint<StringFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a property should contains the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        public void Contains(string value)
        {
            AddFilter(value, "~", null);
        }

        /// <summary>
        /// Asserts that a property should ends with the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        public void EndsWith(string value)
        {
            AddFilter(value, "=~", null);
        }

        /// <summary>
        /// Asserts that a property should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="AndConstraint{StringFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<StringFilterAssertions> NotBe(string value)
        {
            AddFilter(value, "!=", new[] { "!=" });
            return new AndConstraint<StringFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a property should starts with the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        public void StartsWith(string value)
        {
            AddFilter(value, "~=", null);
        }

        #endregion Methods
    }
}