using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for nullable <see cref="DateTime"/> property.
    /// </summary>
    public class NullableDateTimeFilterAssertions : DateTimeFilterAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="NullableDateTimeFilterAssertions" /> class
        /// with the property expression and the filters.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="filters">The filters.</param>
        protected internal NullableDateTimeFilterAssertions(LambdaExpression propertyExpression, List<FilterItem> filters)
            : base(propertyExpression, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a property should has the null value.
        /// </summary>
        /// <returns>The <see cref="OrConstraint{NullableDateTimeFilterAssertions}" /> to add the next filter value.</returns>
        public OrConstraint<NullableDateTimeFilterAssertions> BeNull()
        {
            AddFilter(null, "=", new[] { "=" });
            return new OrConstraint<NullableDateTimeFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a property should not has the null value.
        /// </summary>
        /// <returns>The <see cref="AndConstraint{NullableDateTimeFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<NullableDateTimeFilterAssertions> NotBeNull()
        {
            AddFilter(null, "!=", new[] { "!=" });
            return new AndConstraint<NullableDateTimeFilterAssertions>(this);
        }

        #endregion Methods
    }
}