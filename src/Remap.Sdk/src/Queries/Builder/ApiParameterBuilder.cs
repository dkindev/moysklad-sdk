using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
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
        /// Adds the property name to expand the entity property.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The <see cref="ExpandParameterBuilder" /> to build the next expand parameter.</returns>
        public ExpandParameterBuilder ExpandBy(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ApiException(400, $"The '{nameof(propertyName)}' should not be empty.");

            Expanders.Add(propertyName);
            return new ExpandParameterBuilder(Expanders);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{CustomAssertions}" /> to build the filter for the custom parameter.
        /// </summary>
        /// <param name="parameter">The custom parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{CustomAssertions}" />.</returns>
        public FilterParameterBuilder<CustomFilterAssertions> FilterBy(string parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            var assertions = new CustomFilterAssertions(parameter, new FilterAttribute(), Filters);
            return new FilterParameterBuilder<CustomFilterAssertions>(assertions);
        }

        /// <summary>
        /// Adds the limit parameter.
        /// </summary>
        /// <param name="value">The limit parameter.</param>
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
        public void Offset(int value)
        {
            if (value < 0)
                throw new ApiException(400, "Parameter 'offset' should be greater or equal to 0.");

            _offset = value;
        }

        /// <summary>
        /// Returns the <see cref="OrderParameterBuilder" /> to build the order parameter.
        /// </summary>
        /// <returns>The <see cref="OrderParameterBuilder" />.</returns>
        public OrderParameterBuilder Order()
        {
            return new OrderParameterBuilder(Orders);
        }

        /// <summary>
        /// Adds a search keyword(s) to perform contextual search.
        /// </summary>
        /// <param name="value">The search keyword(s).</param>
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
        /// <param name="parameter">The expression to get the property name.</param>
        /// <returns>The <see cref="ExpandParameterBuilder{T}" /> to build the next expand parameter.</returns>
        public ExpandParameterBuilder<T> ExpandBy<TMember>(Expression<Func<T, TMember>> parameter)
            where TMember : class
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            return ExpandBy(parameter.GetExpandName());
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{StringAssertions}" /> to build the filter for the <see cref="string" /> parameter.
        /// </summary>
        /// <param name="parameter">The string parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{StringAssertions}" />.</returns>
        public FilterParameterBuilder<StringFilterAssertions> FilterBy(Expression<Func<T, string>> parameter)
        {
            var assertions = new StringFilterAssertions(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NumericAssertions}" /> to build the filter for the <see cref="short" /> parameter.
        /// </summary>
        /// <param name="parameter">The short parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NumericAssertions}" />.</returns>
        public FilterParameterBuilder<NumericFilterAssertions<short>> FilterBy(Expression<Func<T, short>> parameter)
        {
            var assertions = new NumericFilterAssertions<short>(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NumericAssertions}" /> to build the filter for the <see cref="uint" /> parameter.
        /// </summary>
        /// <param name="parameter">The uint parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NumericAssertions}" />.</returns>
        public FilterParameterBuilder<NumericFilterAssertions<uint>> FilterBy(Expression<Func<T, uint>> parameter)
        {
            var assertions = new NumericFilterAssertions<uint>(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NumericAssertions}" /> to build the filter for the <see cref="int" /> parameter.
        /// </summary>
        /// <param name="parameter">The int parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NumericAssertions}" /> .</returns>
        public FilterParameterBuilder<NumericFilterAssertions<int>> FilterBy(Expression<Func<T, int>> parameter)
        {
            var assertions = new NumericFilterAssertions<int>(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NumericAssertions}" /> to build the filter for the <see cref="float" /> parameter.
        /// </summary>
        /// <param name="parameter">The float parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NumericAssertions}" />.</returns>
        public FilterParameterBuilder<NumericFilterAssertions<float>> FilterBy(Expression<Func<T, float>> parameter)
        {
            var assertions = new NumericFilterAssertions<float>(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NumericAssertions}" /> to build the filter for the <see cref="double" /> parameter.
        /// </summary>
        /// <param name="parameter">The double parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NumericAssertions}" />.</returns>
        public FilterParameterBuilder<NumericFilterAssertions<double>> FilterBy(Expression<Func<T, double>> parameter)
        {
            var assertions = new NumericFilterAssertions<double>(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NumericAssertions}" /> to build the filter for the <see cref="decimal" /> parameter.
        /// </summary>
        /// <param name="parameter">The decimal parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NumericAssertions}" />.</returns>
        public FilterParameterBuilder<NumericFilterAssertions<decimal>> FilterBy(Expression<Func<T, decimal>> parameter)
        {
            var assertions = new NumericFilterAssertions<decimal>(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NullableNumericAssertions}" /> to build the filter for the nullable <see cref="short" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable short parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableNumericAssertions}" />.</returns>
        public FilterParameterBuilder<NullableNumericFilterAssertions<short>> FilterBy(Expression<Func<T, short?>> parameter)
        {
            var assertions = new NullableNumericFilterAssertions<short>(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NullableNumericAssertions}" /> to build the filter for the nullable <see cref="uint" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable uint parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableNumericAssertions}" />.</returns>
        public FilterParameterBuilder<NullableNumericFilterAssertions<uint>> FilterBy(Expression<Func<T, uint?>> parameter)
        {
            var assertions = new NullableNumericFilterAssertions<uint>(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NullableNumericAssertions}" /> to build the filter for the nullable <see cref="int" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable int parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableNumericAssertions}" />.</returns>
        public FilterParameterBuilder<NullableNumericFilterAssertions<int>> FilterBy(Expression<Func<T, int?>> parameter)
        {
            var assertions = new NullableNumericFilterAssertions<int>(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NullableNumericAssertions}" /> to build the filter for the nullable <see cref="float" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable float parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableNumericAssertions}" />.</returns>
        public FilterParameterBuilder<NullableNumericFilterAssertions<float>> FilterBy(Expression<Func<T, float?>> parameter)
        {
            var assertions = new NullableNumericFilterAssertions<float>(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NullableNumericAssertions}" /> to build the filter for the nullable <see cref="double" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable double parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableNumericAssertions}" />.</returns>
        public FilterParameterBuilder<NullableNumericFilterAssertions<double>> FilterBy(Expression<Func<T, double?>> parameter)
        {
            var assertions = new NullableNumericFilterAssertions<double>(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NullableNumericAssertions}" /> to build the filter for the nullable <see cref="decimal" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable decimal parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableNumericAssertions}" />.</returns>
        public FilterParameterBuilder<NullableNumericFilterAssertions<decimal>> FilterBy(Expression<Func<T, decimal?>> parameter)
        {
            var assertions = new NullableNumericFilterAssertions<decimal>(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{DateTimeAssertions}" /> to build the filter for the <see cref="DateTime" /> parameter.
        /// </summary>
        /// <param name="parameter">The date time parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{DateTimeAssertions}" />.</returns>
        public FilterParameterBuilder<DateTimeFilterAssertions> FilterBy(Expression<Func<T, DateTime>> parameter)
        {
            var assertions = new DateTimeFilterAssertions(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NullableDateTimeAssertions}" /> to build the filter for the nullable <see cref="DateTime" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable date time parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableDateTimeAssertions}" />.</returns>
        public FilterParameterBuilder<NullableDateTimeFilterAssertions> FilterBy(Expression<Func<T, DateTime?>> parameter)
        {
            var assertions = new NullableDateTimeFilterAssertions(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{BooleanAssertions}" /> to build the filter for the <see cref="bool" /> parameter.
        /// </summary>
        /// <param name="parameter">The boolean parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{BooleanAssertions}" />.</returns>
        public FilterParameterBuilder<BooleanFilterAssertions> FilterBy(Expression<Func<T, bool>> parameter)
        {
            var assertions = new BooleanFilterAssertions(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NullableBooleanAssertions}" /> to build the filter for the nullable <see cref="bool" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable boolean parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableBooleanAssertions}" />.</returns>
        public FilterParameterBuilder<NullableBooleanFilterAssertions> FilterBy(Expression<Func<T, bool?>> parameter)
        {
            var assertions = new NullableBooleanFilterAssertions(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{MetaEntityAssertions}" /> to build the filter for the <see cref="MetaEntity" /> parameter.
        /// </summary>
        /// <param name="parameter">The meta entity parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{MetaEntityAssertions}" />.</returns>
        public FilterParameterBuilder<MetaEntityFilterAssertions> FilterBy(Expression<Func<T, object>> parameter)
        {
            var assertions = new MetaEntityFilterAssertions(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{GuidAssertions}" /> to build the filter for the <see cref="Guid" /> parameter.
        /// </summary>
        /// <param name="parameter">The guid parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{GuidAssertions}" />.</returns>
        public FilterParameterBuilder<GuidFilterAssertions> FilterBy(Expression<Func<T, Guid>> parameter)
        {
            var assertions = new GuidFilterAssertions(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{NullableGuidAssertions}" /> to build the filter for the nullable <see cref="Guid" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable guid parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{NullableGuidAssertions}" />.</returns>
        public FilterParameterBuilder<NullableGuidFilterAssertions> FilterBy(Expression<Func<T, Guid?>> parameter)
        {
            var assertions = new NullableGuidFilterAssertions(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{EnumAssertions}" /> to build the filter for the <see cref="Enum" /> parameter.
        /// </summary>
        /// <param name="parameter">The enum parameter.</param>
        /// <returns>The <see cref="FilterParameterBuilder{EnumAssertions}" />.</returns>
        public FilterParameterBuilder<EnumFilterAssertions<TEnum>> FilterBy<TEnum>(Expression<Func<T, TEnum>> parameter) where TEnum : Enum
        {
            var assertions = new EnumFilterAssertions<TEnum>(parameter, Filters);
            return FilterBy(parameter, assertions);
        }

        /// <summary>
        /// Returns the <see cref="OrderParameterBuilder{T}" /> to build the order parameter.
        /// </summary>
        /// <returns>The <see cref="OrderParameterBuilder{T}" />.</returns>
        public new OrderParameterBuilder<T> Order()
        {
            return new OrderParameterBuilder<T>(Orders);
        }

        #endregion Methods

        #region Utilities

        /// <summary>
        /// Returns the <see cref="FilterParameterBuilder{TAssertions}" /> to build filter for the <paramref name="parameter"/>.
        /// </summary>
        /// <param name="parameter">The API parameter.</param>
        /// <param name="assertions">The assertions.</param>
        /// <typeparam name="TProperty">The type of the API parameter.</typeparam>
        /// <typeparam name="TAssertions">The type of the assertions.</typeparam>
        /// <returns>The <see cref="FilterParameterBuilder{TAssertions}" />.</returns>
        protected FilterParameterBuilder<TAssertions> FilterBy<TProperty, TAssertions>(Expression<Func<T, TProperty>> parameter, TAssertions assertions)
            where TAssertions : FilterAssertions
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            return new FilterParameterBuilder<TAssertions>(assertions);
        }

        #endregion Utilities
    }
}