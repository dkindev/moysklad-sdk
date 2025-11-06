using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for <see cref="Guid"/> parameter.
    /// </summary>
    public class GuidFilterAssertions : FilterAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="GuidFilterAssertions" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        protected internal GuidFilterAssertions(LambdaExpression parameter, List<FilterItem> filters)
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
        public OrConstraint<GuidFilterAssertions> Be(Guid value)
        {
            AddFilter(value.ToString(), "=", new[] { "=" });
            return new OrConstraint<GuidFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<GuidFilterAssertions> NotBe(Guid value)
        {
            AddFilter(value.ToString(), "!=", new[] { "!=" });
            return new AndConstraint<GuidFilterAssertions>(this);
        }

        #endregion Methods
    }
}