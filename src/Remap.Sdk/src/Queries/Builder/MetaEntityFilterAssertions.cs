using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for <see cref="MetaEntity"/> property.
    /// </summary>
    public class MetaEntityFilterAssertions : FilterAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="MetaEntityFilterAssertions" /> class
        /// with the property expression and the filters.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="filters">The filters.</param>
        internal MetaEntityFilterAssertions(LambdaExpression propertyExpression, List<FilterItem> filters)
            : base(propertyExpression, filters)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="MetaEntityFilterAssertions" /> class
        /// with the property expression, filter attribute and the filters.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="filterAttribute">The filter attribute.</param>
        /// <param name="filters">The filters.</param>
        internal MetaEntityFilterAssertions(string propertyName, FilterAttribute filterAttribute, List<FilterItem> filters)
            : base(propertyName, filterAttribute, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a property should has the value.
        /// </summary>
        /// <param name="href">The value to assert.</param>
        /// <returns>The <see cref="OrConstraint{MetaEntityFilterAssertions}" /> to add the next filter value.</returns>
        public OrConstraint<MetaEntityFilterAssertions> Be(string href)
        {
            AddFilter(href, "=", new[] { "=" });
            return new OrConstraint<MetaEntityFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a property should has the value.
        /// </summary>
        /// <param name="meta">The meta to assert.</param>
        /// <returns>The <see cref="OrConstraint{MetaEntityFilterAssertions}" /> to add the next filter value.</returns>
        public OrConstraint<MetaEntityFilterAssertions> Be(Meta meta)
        {
            if (meta == null)
                throw new ArgumentNullException(nameof(meta));

            return Be(meta.Href);
        }

        /// <summary>
        /// Asserts that a property should has the value.
        /// </summary>
        /// <param name="metaEntity">The meta entity to assert.</param>
        /// <returns>The <see cref="OrConstraint{MetaEntityFilterAssertions}" /> to add the next filter value.</returns>
        public OrConstraint<MetaEntityFilterAssertions> Be(MetaEntity metaEntity)
        {
            if (metaEntity == null)
                throw new ArgumentNullException(nameof(metaEntity));

            return Be(metaEntity.Meta);
        }

        /// <summary>
        /// Asserts that a property should not has the value.
        /// </summary>
        /// <param name="href">The value to assert.</param>
        /// <returns>The <see cref="AndConstraint{MetaEntityFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<MetaEntityFilterAssertions> NotBe(string href)
        {
            AddFilter(href, "!=", new[] { "!=" });
            return new AndConstraint<MetaEntityFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a property should not has the value.
        /// </summary>
        /// <param name="meta">The meta to assert.</param>
        /// <returns>The <see cref="AndConstraint{MetaEntityFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<MetaEntityFilterAssertions> NotBe(Meta meta)
        {
            if (meta == null)
                throw new ArgumentNullException(nameof(meta));

            return NotBe(meta.Href);
        }

        /// <summary>
        /// Asserts that a property should not has the value.
        /// </summary>
        /// <param name="metaEntity">The meta entity to assert.</param>
        /// <returns>The <see cref="AndConstraint{MetaEntityFilterAssertions}" /> to add the next filter value.</returns>
        public AndConstraint<MetaEntityFilterAssertions> NotBe(MetaEntity metaEntity)
        {
            if (metaEntity == null)
                throw new ArgumentNullException(nameof(metaEntity));

            return NotBe(metaEntity.Meta);
        }

        #endregion Methods
    }
}