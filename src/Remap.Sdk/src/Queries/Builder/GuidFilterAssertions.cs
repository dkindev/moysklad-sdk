using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for <see cref="Guid"/> property.
    /// </summary>
    public class GuidFilterAssertions : FilterAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="GuidFilterAssertions" /> class
        /// with the property expression and the filters.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="filters">The filters.</param>
        protected internal GuidFilterAssertions(LambdaExpression propertyExpression, List<FilterItem> filters)
            : base(propertyExpression, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a property should has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="OrConstraint{GuidFilterAssertions}" /> to add the next filter value.</returns>
        public OrConstraint<GuidFilterAssertions> Be(Guid value)
        {
            AddFilter(value.ToString(), "=", new[] { "=" });
            return new OrConstraint<GuidFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a property should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="AndConstraint{GuidFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<GuidFilterAssertions> NotBe(Guid value)
        {
            AddFilter(value.ToString(), "!=", new[] { "!=" });
            return new AndConstraint<GuidFilterAssertions>(this);
        }

        #endregion Methods
    }
}