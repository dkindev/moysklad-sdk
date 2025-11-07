using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for <see cref="bool"/> property.
    /// </summary>
    public class BooleanFilterAssertions : FilterAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="BooleanFilterAssertions" /> class
        /// with the property expression and the filters.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="filters">The filters.</param>
        protected internal BooleanFilterAssertions(LambdaExpression propertyExpression, List<FilterItem> filters)
            : base(propertyExpression, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a property should has the <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="OrConstraint{BooleanFilterAssertions}" /> to add the next filter value.</returns>
        public OrConstraint<BooleanFilterAssertions> Be(bool value)
        {
            AddFilter(value.ToString().ToLower(), "=", new[] { "=" });
            return new OrConstraint<BooleanFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a property should not has the <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="AndConstraint{BooleanFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<BooleanFilterAssertions> NotBe(bool value)
        {
            AddFilter(value.ToString().ToLower(), "!=", new[] { "!=" });
            return new AndConstraint<BooleanFilterAssertions>(this);
        }

        #endregion Methods
    }
}