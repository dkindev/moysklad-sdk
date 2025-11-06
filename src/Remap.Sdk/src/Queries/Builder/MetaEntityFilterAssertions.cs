using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter for <see cref="MetaEntity"/> parameter.
    /// </summary>
    public class MetaEntityFilterAssertions : FilterAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="MetaEntityFilterAssertions" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal MetaEntityFilterAssertions(LambdaExpression parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="MetaEntityFilterAssertions" /> class
        /// with the parameter expression, filter attribute and the filters.
        /// </summary>
        /// <param name="parameterName">The parameter name.</param>
        /// <param name="filterAttribute">The filter attribute.</param>
        /// <param name="filters">The filters.</param>
        internal MetaEntityFilterAssertions(string parameterName, FilterAttribute filterAttribute, List<FilterItem> filters)
            : base(parameterName, filterAttribute, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="href">The value to assert.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<MetaEntityFilterAssertions> Be(string href)
        {
            AddFilter(href, "=", new[] { "=" });
            return new OrConstraint<MetaEntityFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="meta">The meta to assert.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<MetaEntityFilterAssertions> Be(Meta meta)
        {
            if (meta == null)
                throw new ArgumentNullException(nameof(meta));

            return Be(meta.Href);
        }

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="metaEntity">The meta entity to assert.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<MetaEntityFilterAssertions> Be(MetaEntity metaEntity)
        {
            if (metaEntity == null)
                throw new ArgumentNullException(nameof(metaEntity));

            return Be(metaEntity.Meta);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="href">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<MetaEntityFilterAssertions> NotBe(string href)
        {
            AddFilter(href, "!=", new[] { "!=" });
            return new AndConstraint<MetaEntityFilterAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="meta">The meta to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<MetaEntityFilterAssertions> NotBe(Meta meta)
        {
            if (meta == null)
                throw new ArgumentNullException(nameof(meta));

            return NotBe(meta.Href);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="metaEntity">The meta entity to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<MetaEntityFilterAssertions> NotBe(MetaEntity metaEntity)
        {
            if (metaEntity == null)
                throw new ArgumentNullException(nameof(metaEntity));

            return NotBe(metaEntity.Meta);
        }

        #endregion Methods
    }
}