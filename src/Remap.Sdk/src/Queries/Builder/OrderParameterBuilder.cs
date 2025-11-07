using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Extensions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the order parameter.
    /// </summary>
    public class OrderParameterBuilder
    {
        #region Fields

        /// <summary>
        /// Gets the orders.
        /// </summary>
        protected readonly Dictionary<string, OrderBy> Orders;

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="OrderParameterBuilder" /> class
        /// with the orders.
        /// </summary>
        /// <param name="orders">The orders.</param>
        public OrderParameterBuilder(Dictionary<string, OrderBy> orders)
        {
            Orders = orders;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Adds the order by property name.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public OrderParameterBuilder ThenBy(string propertyName, OrderBy orderBy = OrderBy.Asc)
        {
            AddOrderParameter(propertyName, orderBy);
            return this;
        }

        /// <summary>
        /// Adds the order by property name.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="orderBy">The order action.</param>
        protected virtual void AddOrderParameter(string propertyName, OrderBy orderBy)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new MoySkladException(400, "Property name should not be empty.");

            Orders[propertyName] = orderBy;
        }

        #endregion Methods
    }

    /// <summary>
    /// Represents the assertions to build the order API parameter for <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The concrete type of the meta entity.</typeparam>
    public class OrderParameterBuilder<T> : OrderParameterBuilder where T : class
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="OrderParameterBuilder{T}" /> class
        /// with the orders.
        /// </summary>
        /// <param name="orders">The orders.</param>
        public OrderParameterBuilder(Dictionary<string, OrderBy> orders)
            : base(orders)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Adds the order by property name.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The <see cref="OrderParameterBuilder{T}" /> to build the next order parameter.</returns>
        public new OrderParameterBuilder<T> ThenBy(string propertyName, OrderBy orderBy = OrderBy.Asc)
        {
            AddOrderParameter(propertyName, orderBy);
            return this;
        }

        /// <summary>
        /// Adds the order by selected property.
        /// </summary>
        /// <typeparam name="TMember">The property type.</typeparam>
        /// <param name="parameter">The expression to get the property name.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The <see cref="OrderParameterBuilder{T}" /> to build the next order parameter.</returns>
        public OrderParameterBuilder<T> ThenBy<TMember>(Expression<Func<T, TMember>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            return ThenBy(parameter.GetOrderName(), orderBy);
        }

        #endregion Methods
    }
}