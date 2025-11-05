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
        /// <returns>The expanders.</returns>
        protected List<string> Expanders { get; } = new List<string>();

        /// <summary>
        /// Gets the filters.
        /// </summary>
        /// <returns>The filters.</returns>
        protected List<FilterItem> Filters { get; } = new List<FilterItem>();

        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <returns>The orders.</returns>
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
        /// Returns <see cref="ExpandParameterBuilder" /> to build the expand API parameter.
        /// </summary>
        /// <returns>The expand parameter builder.</returns>
        public ExpandParameterBuilder Expand()
        {
            return new ExpandParameterBuilder(Expanders);
        }

        /// <summary>
        /// Builds the limit API parameter.
        /// </summary>
        /// <param name="value">The query limit.</param>
        public void Limit(int value)
        {
            if (value < 1 || value > 1000)
                throw new ApiException(400, "Parameter 'limit' should be in range: 1-1000.");

            _limit = value;
        }

        /// <summary>
        /// Builds the offset API parameter.
        /// </summary>
        /// <param name="value">The offset in query.</param>
        public void Offset(int value)
        {
            if (value < 0)
                throw new ApiException(400, "Parameter 'offset' should be greater or equal to 0.");

            _offset = value;
        }

        /// <summary>
        /// Returns <see cref="OrderParameterBuilder" /> to build the order API parameter.
        /// </summary>
        /// <returns>The order parameter builder.</returns>
        public OrderParameterBuilder Order()
        {
            return new OrderParameterBuilder(Orders);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{CustomAssertions}" /> to build assertions for the custom parameter.
        /// </summary>
        /// <param name="parameter">The custom parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<CustomAssertions> Parameter(string parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            var assertions = new CustomAssertions(parameter, new FilterAttribute(), Filters);
            return new ParameterBuilder<CustomAssertions>(assertions);
        }

        /// <summary>
        /// Builds the search API parameter.
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
        /// Returns <see cref="ExpandParameterBuilder{T}" /> to build the expand API parameter.
        /// </summary>
        /// <returns>The expand parameter builder.</returns>
        public new ExpandParameterBuilder<T> Expand()
        {
            return new ExpandParameterBuilder<T>(Expanders);
        }

        /// <summary>
        /// Returns <see cref="OrderParameterBuilder{T}" /> to build the order API parameter.
        /// </summary>
        /// <returns>The order parameter builder.</returns>
        public new OrderParameterBuilder<T> Order()
        {
            return new OrderParameterBuilder<T>(Orders);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{StringAssertions}" /> to build assertions for the current <see cref="string" /> parameter.
        /// </summary>
        /// <param name="parameter">The string parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<StringAssertions> Parameter(Expression<Func<T, string>> parameter)
        {
            var assertions = new StringAssertions(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NumericAssertions}" /> to build assertions for the current <see cref="short" /> parameter.
        /// </summary>
        /// <param name="parameter">The short parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NumericAssertions<short>> Parameter(Expression<Func<T, short>> parameter)
        {
            var assertions = new NumericAssertions<short>(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NumericAssertions}" /> to build assertions for the current <see cref="uint" /> parameter.
        /// </summary>
        /// <param name="parameter">The uint parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NumericAssertions<uint>> Parameter(Expression<Func<T, uint>> parameter)
        {
            var assertions = new NumericAssertions<uint>(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NumericAssertions}" /> to build assertions for the current <see cref="int" /> parameter.
        /// </summary>
        /// <param name="parameter">The int parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NumericAssertions<int>> Parameter(Expression<Func<T, int>> parameter)
        {
            var assertions = new NumericAssertions<int>(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NumericAssertions}" /> to build assertions for the current <see cref="float" /> parameter.
        /// </summary>
        /// <param name="parameter">The float parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NumericAssertions<float>> Parameter(Expression<Func<T, float>> parameter)
        {
            var assertions = new NumericAssertions<float>(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NumericAssertions}" /> to build assertions for the current <see cref="double" /> parameter.
        /// </summary>
        /// <param name="parameter">The double parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NumericAssertions<double>> Parameter(Expression<Func<T, double>> parameter)
        {
            var assertions = new NumericAssertions<double>(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NumericAssertions}" /> to build assertions for the current <see cref="decimal" /> parameter.
        /// </summary>
        /// <param name="parameter">The decimal parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NumericAssertions<decimal>> Parameter(Expression<Func<T, decimal>> parameter)
        {
            var assertions = new NumericAssertions<decimal>(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableNumericAssertions}" /> to build assertions for the current nullable <see cref="short" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable short parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableNumericAssertions<short>> Parameter(Expression<Func<T, short?>> parameter)
        {
            var assertions = new NullableNumericAssertions<short>(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableNumericAssertions}" /> to build assertions for the current nullable <see cref="uint" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable uint parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableNumericAssertions<uint>> Parameter(Expression<Func<T, uint?>> parameter)
        {
            var assertions = new NullableNumericAssertions<uint>(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableNumericAssertions}" /> to build assertions for the current nullable <see cref="int" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable int parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableNumericAssertions<int>> Parameter(Expression<Func<T, int?>> parameter)
        {
            var assertions = new NullableNumericAssertions<int>(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableNumericAssertions}" /> to build assertions for the current nullable <see cref="float" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable float parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableNumericAssertions<float>> Parameter(Expression<Func<T, float?>> parameter)
        {
            var assertions = new NullableNumericAssertions<float>(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableNumericAssertions}" /> to build assertions for the current nullable <see cref="double" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable double parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableNumericAssertions<double>> Parameter(Expression<Func<T, double?>> parameter)
        {
            var assertions = new NullableNumericAssertions<double>(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableNumericAssertions}" /> to build assertions for the current nullable <see cref="decimal" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable decimal parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableNumericAssertions<decimal>> Parameter(Expression<Func<T, decimal?>> parameter)
        {
            var assertions = new NullableNumericAssertions<decimal>(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{DateTimeAssertions}" /> to build assertions for the current <see cref="DateTime" /> parameter.
        /// </summary>
        /// <param name="parameter">The date time parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<DateTimeAssertions> Parameter(Expression<Func<T, DateTime>> parameter)
        {
            var assertions = new DateTimeAssertions(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableDateTimeAssertions}" /> to build assertions for the current nullable <see cref="DateTime" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable date time parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableDateTimeAssertions> Parameter(Expression<Func<T, DateTime?>> parameter)
        {
            var assertions = new NullableDateTimeAssertions(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{BooleanAssertions}" /> to build assertions for the current <see cref="bool" /> parameter.
        /// </summary>
        /// <param name="parameter">The boolean parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<BooleanAssertions> Parameter(Expression<Func<T, bool>> parameter)
        {
            var assertions = new BooleanAssertions(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableBooleanAssertions}" /> to build assertions for the current nullable <see cref="bool" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable boolean parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableBooleanAssertions> Parameter(Expression<Func<T, bool?>> parameter)
        {
            var assertions = new NullableBooleanAssertions(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{MetaEntityAssertions}" /> to build assertions for the current <see cref="MetaEntity" /> parameter.
        /// </summary>
        /// <param name="parameter">The meta entity parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<MetaEntityAssertions> Parameter(Expression<Func<T, object>> parameter)
        {
            var assertions = new MetaEntityAssertions(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{GuidAssertions}" /> to build assertions for the current <see cref="Guid" /> parameter.
        /// </summary>
        /// <param name="parameter">The guid parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<GuidAssertions> Parameter(Expression<Func<T, Guid>> parameter)
        {
            var assertions = new GuidAssertions(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableGuidAssertions}" /> to build assertions for the current nullable <see cref="Guid" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable guid parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableGuidAssertions> Parameter(Expression<Func<T, Guid?>> parameter)
        {
            var assertions = new NullableGuidAssertions(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{EnumAssertions}" /> to build assertions for the current <see cref="Enum" /> parameter.
        /// </summary>
        /// <param name="parameter">The enum parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<EnumAssertions<TEnum>> Parameter<TEnum>(Expression<Func<T, TEnum>> parameter) where TEnum : Enum
        {
            var assertions = new EnumAssertions<TEnum>(parameter, Filters);
            return Parameter(parameter, assertions);
        }

        #endregion Methods

        #region Utilities

        /// <summary>
        /// Returns <see cref="ParameterBuilder{TAssertions}" /> to build assertions for the API parameter.
        /// </summary>
        /// <param name="parameter">The API parameter.</param>
        /// <param name="assertions">The assertions.</param>
        /// <typeparam name="TProperty">The type of the API parameter.</typeparam>
        /// <typeparam name="TAssertions">The type of the assertions.</typeparam>
        /// <returns>The parameter builder containing the assertions.</returns>
        protected ParameterBuilder<TAssertions> Parameter<TProperty, TAssertions>(Expression<Func<T, TProperty>> parameter, TAssertions assertions)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            return new ParameterBuilder<TAssertions>(assertions);
        }

        #endregion Utilities
    }
}