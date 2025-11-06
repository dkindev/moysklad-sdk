using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for nullable <see cref="bool"/> parameter.
    /// </summary>
    public class NullableBooleanFilterAssertions : BooleanFilterAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="NullableBooleanFilterAssertions" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal NullableBooleanFilterAssertions(LambdaExpression parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the null value.
        /// </summary>
        /// <returns>The or constraint.</returns>
        public OrConstraint<NullableBooleanFilterAssertions> BeNull()
        {
            AddFilter(null, "=", new[] { "=" });
            return new OrConstraint<NullableBooleanFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the null value.
        /// </summary>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NullableBooleanFilterAssertions> NotBeNull()
        {
            AddFilter(null, "!=", new[] { "!=" });
            return new AndConstraint<NullableBooleanFilterAssertions>(this);
        }

        #endregion Methods
    }
}