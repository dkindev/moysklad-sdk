using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Extensions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the builder to prepare the expand parameter.
    /// </summary>
    public class ExpandParameterBuilder
    {
        #region Fields

        /// <summary>
        /// Gets the orders.
        /// </summary>
        protected List<string> Expanders { get; }

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ExpandParameterBuilder" /> class
        /// with the expanders.
        /// </summary>
        /// <param name="expanders">The expanders.</param>
        public ExpandParameterBuilder(List<string> expanders)
        {
            Expanders = expanders;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Adds the expand by property name.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The <see cref="ExpandParameterBuilder" /> to build the next expand parameter.</returns>
        public ExpandParameterBuilder ThenBy(string propertyName)
        {
            AddExpandParameter(propertyName);
            return this;
        }

        /// <summary>
        /// Adds the expand by property name.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        protected virtual void AddExpandParameter(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ApiException(400, $"The '{nameof(propertyName)}' should not be empty.");

            Expanders.Add(propertyName);
        }

        #endregion Methods
    }

    /// <summary>
    /// Represents the builder to prepare the expand parameter for <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The concrete type of the meta entity.</typeparam>
    public class ExpandParameterBuilder<T> : ExpandParameterBuilder where T : class
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ExpandParameterBuilder{T}" /> class
        /// with the expanders.
        /// </summary>
        /// <param name="expanders">The expanders.</param>
        public ExpandParameterBuilder(List<string> expanders)
            : base(expanders)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Adds the expand by selected property.
        /// </summary>
        /// <typeparam name="TMember">The property type.</typeparam>
        /// <param name="parameter">The expression to get the property name.</param>
        /// <returns>The <see cref="ExpandParameterBuilder{T}" /> to build the next expand parameter.</returns>
        public ExpandParameterBuilder<T> ThenBy<TMember>(Expression<Func<T, TMember>> parameter)
            where TMember : class
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            return ThenBy(parameter.GetExpandName());
        }

        /// <summary>
        /// Adds the expand by property name.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The <see cref="ExpandParameterBuilder{T}" /> to build the next expand parameter.</returns>
        public new ExpandParameterBuilder<T> ThenBy(string propertyName)
        {
            AddExpandParameter(propertyName);
            return this;
        }

        #endregion Methods
    }
}