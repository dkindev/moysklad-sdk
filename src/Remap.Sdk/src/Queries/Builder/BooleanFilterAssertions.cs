using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for <see cref="bool"/> parameter.
    /// </summary>
    public class BooleanFilterAssertions : FilterAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="BooleanFilterAssertions" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        protected internal BooleanFilterAssertions(LambdaExpression parameter, List<FilterItem> filters)
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
        public OrConstraint<BooleanFilterAssertions> Be(bool value)
        {
            AddFilter(value.ToString().ToLower(), "=", new[] { "=" });
            return new OrConstraint<BooleanFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<BooleanFilterAssertions> NotBe(bool value)
        {
            AddFilter(value.ToString().ToLower(), "!=", new[] { "!=" });
            return new AndConstraint<BooleanFilterAssertions>(this);
        }

        #endregion Methods
    }
}