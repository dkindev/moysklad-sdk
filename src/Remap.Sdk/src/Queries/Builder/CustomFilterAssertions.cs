using System.Collections.Generic;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for custom property.
    /// </summary>
    public class CustomFilterAssertions : FilterAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="CustomFilterAssertions" /> class
        /// with the property expression, filter attribute and the filters.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="filterAttribute">The filter attribute.</param>
        /// <param name="filters">The filters.</param>
        internal CustomFilterAssertions(string propertyName, FilterAttribute filterAttribute, List<FilterItem> filters)
            : base(propertyName, filterAttribute, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a property should has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="OrConstraint{CustomFilterAssertions}" /> to add the next filter value.</returns>
        public OrConstraint<CustomFilterAssertions> Be(string value)
        {
            AddFilter(value, "=", new[] { "=" });
            return new OrConstraint<CustomFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a property should be greater or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="AndConstraint{CustomFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<CustomFilterAssertions> BeGreaterOrEqualTo(string value)
        {
            AddFilter(value, ">=", new[] { "<=", "<", ">" });
            return new AndConstraint<CustomFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a property should be greater than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="AndConstraint{CustomFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<CustomFilterAssertions> BeGreaterThan(string value)
        {
            AddFilter(value, ">", new[] { "<", "<=", ">=" });
            return new AndConstraint<CustomFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a property should be less or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="AndConstraint{CustomFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<CustomFilterAssertions> BeLessOrEqualTo(string value)
        {
            AddFilter(value, "<=", new[] { ">=", "<", ">" });
            return new AndConstraint<CustomFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a property should be less than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The <see cref="AndConstraint{CustomFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<CustomFilterAssertions> BeLessThan(string value)
        {
            AddFilter(value, "<", new[] { ">", "<=", ">=" });
            return new AndConstraint<CustomFilterAssertions>(this);
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
        /// <returns>The <see cref="AndConstraint{CustomFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<CustomFilterAssertions> NotBe(string value)
        {
            AddFilter(value, "!=", new[] { "!=" });
            return new AndConstraint<CustomFilterAssertions>(this);
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