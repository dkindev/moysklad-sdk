using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for nullable <see cref="bool"/> property.
    /// </summary>
    public class NullableBooleanFilterAssertions : BooleanFilterAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="NullableBooleanFilterAssertions" /> class
        /// with the property expression and the filters.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="filters">The filters.</param>
        internal NullableBooleanFilterAssertions(LambdaExpression propertyExpression, List<FilterItem> filters)
            : base(propertyExpression, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a property should has the null value.
        /// </summary>
        /// <returns>The <see cref="OrConstraint{NullableBooleanFilterAssertions}" /> to add the next filter value.</returns>
        public OrConstraint<NullableBooleanFilterAssertions> BeNull()
        {
            AddFilter(null, "=", new[] { "=" });
            return new OrConstraint<NullableBooleanFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a property should not has the null value.
        /// </summary>
        /// <returns>The <see cref="AndConstraint{NullableBooleanFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<NullableBooleanFilterAssertions> NotBeNull()
        {
            AddFilter(null, "!=", new[] { "!=" });
            return new AndConstraint<NullableBooleanFilterAssertions>(this);
        }

        #endregion Methods
    }
}