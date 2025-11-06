using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confiti.MoySklad.Remap.Client;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for <see cref="DateTime"/> parameter.
    /// </summary>
    public class DateTimeFilterAssertions : FilterAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="DateTimeFilterAssertions" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        protected internal DateTimeFilterAssertions(LambdaExpression parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<DateTimeFilterAssertions> Be(DateTime value, string format = ApiDefaults.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), "=", new[] { "=" });
            return new OrConstraint<DateTimeFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeFilterAssertions> BeGreaterOrEqualTo(DateTime value, string format = ApiDefaults.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), ">=", new[] { "<=", "<", ">" });
            return new AndConstraint<DateTimeFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeFilterAssertions> BeGreaterThan(DateTime value, string format = ApiDefaults.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), ">", new[] { "<", "<=", ">=" });
            return new AndConstraint<DateTimeFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be less or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeFilterAssertions> BeLessOrEqualTo(DateTime value, string format = ApiDefaults.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), "<=", new[] { ">=", "<", ">" });
            return new AndConstraint<DateTimeFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be less than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeFilterAssertions> BeLessThan(DateTime value, string format = ApiDefaults.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), "<", new[] { ">", "<=", ">=" });
            return new AndConstraint<DateTimeFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeFilterAssertions> NotBe(DateTime value, string format = ApiDefaults.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), "!=", new[] { "!=" });
            return new AndConstraint<DateTimeFilterAssertions>(this);
        }

        #endregion Methods
    }
}