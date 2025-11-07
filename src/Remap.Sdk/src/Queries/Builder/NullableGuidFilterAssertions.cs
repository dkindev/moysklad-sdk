using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for nullable <see cref="Guid"/> property.
    /// </summary>
    public class NullableGuidFilterAssertions : GuidFilterAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="NullableGuidFilterAssertions" /> class
        /// with the property expression and the filters.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="filters">The filters.</param>
        protected internal NullableGuidFilterAssertions(LambdaExpression propertyExpression, List<FilterItem> filters)
            : base(propertyExpression, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a property should has the null value.
        /// </summary>
        /// <returns>The <see cref="OrConstraint{NullableGuidFilterAssertions}" /> to add the next filter value.</returns>
        public OrConstraint<NullableGuidFilterAssertions> BeNull()
        {
            AddFilter(null, "=", new[] { "=" });
            return new OrConstraint<NullableGuidFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a property should not has the null value.
        /// </summary>
        /// <returns>The <see cref="AndConstraint{NullableGuidFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<NullableGuidFilterAssertions> NotBeNull()
        {
            AddFilter(null, "!=", new[] { "!=" });
            return new AndConstraint<NullableGuidFilterAssertions>(this);
        }

        #endregion Methods
    }
}