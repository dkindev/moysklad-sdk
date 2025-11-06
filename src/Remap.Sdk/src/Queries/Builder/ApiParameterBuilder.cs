using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Extensions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an helper class to build API parameters.
    /// </summary>
    public class ApiParameterBuilder
    {
        #region Fields

        private int? _limit;
        private int? _offset;
        private string _search;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the expanders.
        /// </summary>
        protected List<string> Expanders { get; } = new List<string>();

        /// <summary>
        /// Gets the filters.
        /// </summary>
        protected List<FilterItem> Filters { get; } = new List<FilterItem>();

        /// <summary>
        /// Gets the orders.
        /// </summary>
        protected Dictionary<string, OrderBy> Orders { get; } = new Dictionary<string, OrderBy>();

        #endregion Properties

        #region Methods

        /// <summary>
        /// Builds the API parameters.
        /// </summary>
        /// <returns>The query.</returns>
        public virtual Dictionary<string, string> Build()
        {
            var result = new Dictionary<string, string>();

            if (Filters.Count > 0)
                result["filter"] = string.Join(";", Filters.Select(f => $"{f.Name}{f.Operator}{f.Value}").ToArray());

            if (Expanders.Count > 0)
                result["expand"] = string.Join(",", Expanders);

            if (Orders.Count > 0)
                result["order"] = string.Join(";", Orders.Select(o => $"{o.Key},{o.Value.GetParameterName()}").ToArray());

            if (!string.IsNullOrWhiteSpace(_search))
                result["search"] = _search;

            if (_limit.HasValue)
                result["limit"] = _limit.Value.ToString();

            if (_offset.HasValue)
                result["offset"] = _offset.Value.ToString();

            return result;
        }

        /// <summary>
        /// Adds the expand by property name.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The <see cref="ExpandParameterBuilder" /> to build the next expand parameter.</returns>
        /// <exception cref="ApiException">Throws if <paramref name="propertyName"/> is empty.</exception>
        public ExpandParameterBuilder ExpandBy(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ApiException(400, $"The '{nameof(propertyName)}' should not be empty.");

            Expanders.Add(propertyName);
            return new ExpandParameterBuilder(Expanders);
        }

        /// <summary>
        /// Adds the filter by property name.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{CustomAssertions}" /> to build the filter parameter.</returns>
        /// <exception cref="ApiException">Throws if <paramref name="propertyName"/> is empty.</exception>
        public FilterParameterBuilder<CustomFilterAssertions> FilterBy(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ApiException(400, $"The '{nameof(propertyName)}' should not be empty.");

            var assertions = new CustomFilterAssertions(propertyName, new FilterAttribute(), Filters);
            return new FilterParameterBuilder<CustomFilterAssertions>(assertions);
        }

        /// <summary>
        /// Adds the limit parameter.
        /// </summary>
        /// <param name="value">The limit parameter.</param>
        /// <exception cref="ApiException">Throws if the <paramref name="value"/> isn't in the range 1 - 1000.</exception>
        public void Limit(int value)
        {
            if (value < 1 || value > 1000)
                throw new ApiException(400, "Parameter 'limit' should be in range: 1-1000.");

            _limit = value;
        }

        /// <summary>
        /// Adds the offset parameter.
        /// </summary>
        /// <param name="value">The offset parameter.</param>
        /// <exception cref="ApiException">Throws if the <paramref name="value"/> less than 0.</exception>
        public void Offset(int value)
        {
            if (value < 0)
                throw new ApiException(400, "Parameter 'offset' should be greater or equal to 0.");

            _offset = value;
        }

        /// <summary>
        /// Adds the order by property name.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The <see cref="OrderParameterBuilder" /> to build the next order parameter.</returns>
        /// <exception cref="ApiException">Throws if <paramref name="propertyName"/> is empty.</exception>
        public OrderParameterBuilder OrderBy(string propertyName, OrderBy orderBy = Queries.OrderBy.Asc)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ApiException(400, $"The '{nameof(propertyName)}' should not be empty.");

            Orders[propertyName] = orderBy;
            return new OrderParameterBuilder(Orders);
        }

        /// <summary>
        /// Adds a search keyword(s) to perform contextual search.
        /// </summary>
        /// <param name="value">The search keyword(s).</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="value"/> is null.</exception>
        public void Search(string value)
        {
            _search = value ?? throw new ArgumentNullException(nameof(value));
        }

        #endregion Methods
    }

    /// <summary>
    /// Represents an helper class to build API parameters for concrete query type.
    /// </summary>
    /// <typeparam name="T">The concrete type of the meta entity query.</typeparam>
    public class ApiParameterBuilder<T> : ApiParameterBuilder where T : class
    {
        #region Methods

        /// <summary>
        /// Adds the property name to expand the entity property.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The <see cref="ExpandParameterBuilder{T}" /> to build the next expand parameter.</returns>
        /// <exception cref="ApiException">Throws if <paramref name="propertyName"/> is empty.</exception>
        public new ExpandParameterBuilder<T> ExpandBy(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ApiException(400, $"The '{nameof(propertyName)}' should not be empty.");

            Expanders.Add(propertyName);
            return new ExpandParameterBuilder<T>(Expanders);
        }

        /// <summary>
        /// Adds the property name to expand the entity property.
        /// </summary>
        /// <typeparam name="TMember">The property type.</typeparam>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="ExpandParameterBuilder{T}" /> to build the next expand parameter.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="propertyExpression"/> is null.</exception>
        public ExpandParameterBuilder<T> ExpandBy<TMember>(Expression<Func<T, TMember>> propertyExpression)
            where TMember : class
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));

            return ExpandBy(propertyExpression.GetExpandName());
        }

        /// <summary>
        /// Adds the filter by selected property.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{StringAssertions}" />.</returns>
        public FilterParameterBuilder<StringFilterAssertions> FilterBy(Expression<Func<T, string>> propertyExpression)
        {
            var assertions = new StringFilterAssertions(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NumericAssertions}" /> to build the filter for the <see cref="short" /> parameter.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NumericAssertions}" />.</returns>
        public FilterParameterBuilder<NumericFilterAssertions<short>> FilterBy(Expression<Func<T, short>> propertyExpression)
        {
            var assertions = new NumericFilterAssertions<short>(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NumericAssertions}" /> to build the filter for the <see cref="uint" /> parameter.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NumericAssertions}" />.</returns>
        public FilterParameterBuilder<NumericFilterAssertions<uint>> FilterBy(Expression<Func<T, uint>> propertyExpression)
        {
            var assertions = new NumericFilterAssertions<uint>(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NumericAssertions}" /> to build the filter for the <see cref="int" /> parameter.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NumericAssertions}" /> .</returns>
        public FilterParameterBuilder<NumericFilterAssertions<int>> FilterBy(Expression<Func<T, int>> propertyExpression)
        {
            var assertions = new NumericFilterAssertions<int>(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NumericAssertions}" /> to build the filter for the <see cref="float" /> parameter.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NumericAssertions}" />.</returns>
        public FilterParameterBuilder<NumericFilterAssertions<float>> FilterBy(Expression<Func<T, float>> propertyExpression)
        {
            var assertions = new NumericFilterAssertions<float>(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NumericAssertions}" /> to build the filter for the <see cref="double" /> parameter.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NumericAssertions}" />.</returns>
        public FilterParameterBuilder<NumericFilterAssertions<double>> FilterBy(Expression<Func<T, double>> propertyExpression)
        {
            var assertions = new NumericFilterAssertions<double>(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NumericAssertions}" /> to build the filter for the <see cref="decimal" /> parameter.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NumericAssertions}" />.</returns>
        public FilterParameterBuilder<NumericFilterAssertions<decimal>> FilterBy(Expression<Func<T, decimal>> propertyExpression)
        {
            var assertions = new NumericFilterAssertions<decimal>(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Adds the filter by selected property.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableNumericAssertions}" />.</returns>
        public FilterParameterBuilder<NullableNumericFilterAssertions<short>> FilterBy(Expression<Func<T, short?>> propertyExpression)
        {
            var assertions = new NullableNumericFilterAssertions<short>(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Adds the filter by selected property.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableNumericAssertions}" />.</returns>
        public FilterParameterBuilder<NullableNumericFilterAssertions<uint>> FilterBy(Expression<Func<T, uint?>> propertyExpression)
        {
            var assertions = new NullableNumericFilterAssertions<uint>(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Adds the filter by selected property.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableNumericAssertions}" />.</returns>
        public FilterParameterBuilder<NullableNumericFilterAssertions<int>> FilterBy(Expression<Func<T, int?>> propertyExpression)
        {
            var assertions = new NullableNumericFilterAssertions<int>(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Adds the filter by selected property.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableNumericAssertions}" />.</returns>
        public FilterParameterBuilder<NullableNumericFilterAssertions<float>> FilterBy(Expression<Func<T, float?>> propertyExpression)
        {
            var assertions = new NullableNumericFilterAssertions<float>(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Adds the filter by selected property.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableNumericAssertions}" />.</returns>
        public FilterParameterBuilder<NullableNumericFilterAssertions<double>> FilterBy(Expression<Func<T, double?>> propertyExpression)
        {
            var assertions = new NullableNumericFilterAssertions<double>(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Adds the filter by selected property.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableNumericAssertions}" />.</returns>
        public FilterParameterBuilder<NullableNumericFilterAssertions<decimal>> FilterBy(Expression<Func<T, decimal?>> propertyExpression)
        {
            var assertions = new NullableNumericFilterAssertions<decimal>(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Adds the filter by selected property.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{DateTimeAssertions}" />.</returns>
        public FilterParameterBuilder<DateTimeFilterAssertions> FilterBy(Expression<Func<T, DateTime>> propertyExpression)
        {
            var assertions = new DateTimeFilterAssertions(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Adds the filter by selected property.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableDateTimeAssertions}" />.</returns>
        public FilterParameterBuilder<NullableDateTimeFilterAssertions> FilterBy(Expression<Func<T, DateTime?>> propertyExpression)
        {
            var assertions = new NullableDateTimeFilterAssertions(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Adds the filter by selected property.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{BooleanAssertions}" />.</returns>
        public FilterParameterBuilder<BooleanFilterAssertions> FilterBy(Expression<Func<T, bool>> propertyExpression)
        {
            var assertions = new BooleanFilterAssertions(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Adds the filter by selected property.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableBooleanAssertions}" />.</returns>
        public FilterParameterBuilder<NullableBooleanFilterAssertions> FilterBy(Expression<Func<T, bool?>> propertyExpression)
        {
            var assertions = new NullableBooleanFilterAssertions(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Adds the filter by selected property.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{MetaEntityAssertions}" />.</returns>
        public FilterParameterBuilder<MetaEntityFilterAssertions> FilterBy(Expression<Func<T, object>> propertyExpression)
        {
            var assertions = new MetaEntityFilterAssertions(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Adds the filter by selected property.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{GuidAssertions}" />.</returns>
        public FilterParameterBuilder<GuidFilterAssertions> FilterBy(Expression<Func<T, Guid>> propertyExpression)
        {
            var assertions = new GuidFilterAssertions(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Adds the filter by selected property.
        /// </summary>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableGuidAssertions}" />.</returns>
        public FilterParameterBuilder<NullableGuidFilterAssertions> FilterBy(Expression<Func<T, Guid?>> propertyExpression)
        {
            var assertions = new NullableGuidFilterAssertions(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Adds the filter by selected property.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <returns>The <see cref="FilterParameterBuilder{EnumAssertions}" />.</returns>
        public FilterParameterBuilder<EnumFilterAssertions<TEnum>> FilterBy<TEnum>(Expression<Func<T, TEnum>> propertyExpression)
            where TEnum : Enum
        {
            var assertions = new EnumFilterAssertions<TEnum>(propertyExpression, Filters);
            return FilterBy(propertyExpression, assertions);
        }

        /// <summary>
        /// Adds the order by selected property.
        /// </summary>
        /// <typeparam name="TMember">The property type.</typeparam>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The <see cref="OrderParameterBuilder{T}" /> to build the next order parameter.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="propertyExpression"/> is null.</exception>
        public OrderParameterBuilder<T> OrderBy<TMember>(Expression<Func<T, TMember>> propertyExpression, OrderBy orderBy = Queries.OrderBy.Asc)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));

            return OrderBy(propertyExpression.GetOrderName(), orderBy);
        }

        /// <summary>
        /// Adds the order by property name.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The <see cref="OrderParameterBuilder{T}" /> to build the next order parameter.</returns>
        /// <exception cref="ApiException">Throws if <paramref name="propertyName"/> is empty.</exception>
        public new OrderParameterBuilder<T> OrderBy(string propertyName, OrderBy orderBy = Queries.OrderBy.Asc)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ApiException(400, $"The '{nameof(propertyName)}' should not be empty.");

            Orders[propertyName] = orderBy;
            return new OrderParameterBuilder<T>(Orders);
        }

        #endregion Methods

        #region Utilities

        /// <summary>
        /// Adds the filter by selected property.
        /// </summary>
        /// <typeparam name="TProperty">The property type.</typeparam>
        /// <typeparam name="TAssertions">The type of the assertions.</typeparam>
        /// <param name="propertyExpression">The expression to get the property name.</param>
        /// <param name="assertions">The assertions.</param>
        /// <returns>The <see cref="FilterParameterBuilder{TAssertions}" />.</returns>
        protected FilterParameterBuilder<TAssertions> FilterBy<TProperty, TAssertions>(Expression<Func<T, TProperty>> propertyExpression, TAssertions assertions)
            where TAssertions : FilterAssertions
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));

            return new FilterParameterBuilder<TAssertions>(assertions);
        }

        #endregion Utilities
    }
}