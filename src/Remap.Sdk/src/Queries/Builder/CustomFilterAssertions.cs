using System.Collections.Generic;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for custom parameter.
    /// </summary>
    public class CustomFilterAssertions : FilterAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="CustomFilterAssertions" /> class
        /// with the parameter expression, filter attribute and the filters.
        /// </summary>
        /// <param name="parameterName">The parameter name.</param>
        /// <param name="filterAttribute">The filter attribute.</param>
        /// <param name="filters">The filters.</param>
        internal CustomFilterAssertions(string parameterName, FilterAttribute filterAttribute, List<FilterItem> filters)
            : base(parameterName, filterAttribute, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<CustomFilterAssertions> Be(string value)
        {
            AddFilter(value, "=", new[] { "=" });
            return new OrConstraint<CustomFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<CustomFilterAssertions> BeGreaterOrEqualTo(string value)
        {
            AddFilter(value, ">=", new[] { "<=", "<", ">" });
            return new AndConstraint<CustomFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<CustomFilterAssertions> BeGreaterThan(string value)
        {
            AddFilter(value, ">", new[] { "<", "<=", ">=" });
            return new AndConstraint<CustomFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be less or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<CustomFilterAssertions> BeLessOrEqualTo(string value)
        {
            AddFilter(value, "<=", new[] { ">=", "<", ">" });
            return new AndConstraint<CustomFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be less than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<CustomFilterAssertions> BeLessThan(string value)
        {
            AddFilter(value, "<", new[] { ">", "<=", ">=" });
            return new AndConstraint<CustomFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should contains the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        public void Contains(string value)
        {
            AddFilter(value, "~", null);
        }

        /// <summary>
        /// Asserts that a parameter should ends with the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        public void EndsWith(string value)
        {
            AddFilter(value, "=~", null);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<CustomFilterAssertions> NotBe(string value)
        {
            AddFilter(value, "!=", new[] { "!=" });
            return new AndConstraint<CustomFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should starts with the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        public void StartsWith(string value)
        {
            AddFilter(value, "~=", null);
        }

        #endregion Methods
    }
}