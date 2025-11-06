using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Extensions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the filter parameter.
    /// </summary>
    public abstract class FilterAssertions
    {
        #region Properties

        /// <summary>
        /// Gets the filters.
        /// </summary>
        protected List<FilterItem> Filters { get; }

        /// <summary>
        /// Gets the parameter filter.
        /// </summary>
        protected FilterAttribute ParameterFilter { get; }

        /// <summary>
        /// Gets the parameter name.
        /// </summary>
        protected string ParameterName { get; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="FilterAssertions" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal FilterAssertions(LambdaExpression parameter, List<FilterItem> filters)
            : this(parameter.GetFilterName(), parameter.GetFilter(), filters)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="FilterAssertions" /> class
        /// with the parameter expression, filter attribute and the filters.
        /// </summary>
        /// <param name="parameterName">The parameter name.</param>
        /// <param name="filterAttribute">The filter attribute.</param>
        /// <param name="filters">The filters.</param>
        internal FilterAssertions(string parameterName, FilterAttribute filterAttribute, List<FilterItem> filters)
        {
            if (parameterName == null)
                throw new ArgumentNullException(nameof(parameterName));

            if (filterAttribute == null)
                throw new ArgumentNullException(nameof(filterAttribute));

            if (string.IsNullOrWhiteSpace(parameterName))
                throw new ApiException(400, "Parameter name should not be empty.");

            ParameterName = parameterName;
            ParameterFilter = filterAttribute;
            Filters = filters;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Adds the filter.
        /// </summary>
        /// <param name="value">The value of the parameter.</param>
        /// <param name="operator">The operator.</param>
        /// <param name="allowedOperators">The allowed operators.</param>
        protected virtual void AddFilter(string value, string @operator, string[] allowedOperators = null)
        {
            if (ParameterFilter.OverriddenOperators?.Contains(@operator) == false)
                throw new ApiException(400, $"Parameter '{ParameterName}' with operator '{@operator}' isn't supported.");

            if (!ParameterFilter.AllowNull && string.IsNullOrEmpty(value))
                throw new ApiException(400, $"Parameter '{ParameterName}' should have a value.");

            if (!ParameterFilter.AllowContinueConstraint && Filters.Any(f => f.Name == ParameterName))
                throw new ApiException(400, $"Parameter '{ParameterName}' should be specify only onсe.");

            if (Filters.Any(f => f.Name == ParameterName) && (allowedOperators == null || Filters.Where(f => f.Name == ParameterName).Select(f => f.Operator).Except(allowedOperators).Any()))
                throw new ApiException(400, $"Parameter '{ParameterName}' with operator '{@operator}' doesn't support multiple operators {(allowedOperators == null ? "" : $"except: {string.Join(", ", allowedOperators)}")}.");

            Filters.Add(new FilterItem(ParameterName, @operator, value));
        }

        #endregion Methods
    }
}