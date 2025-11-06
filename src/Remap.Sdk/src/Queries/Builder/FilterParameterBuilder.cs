namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an helper class to build the filter parameter.
    /// </summary>
    /// <typeparam name="T">The type of the filter assertions.</typeparam>
    public class FilterParameterBuilder<T> where T : FilterAssertions
    {
        #region Fields

        private readonly T _assertion;

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="FilterParameterBuilder{T}" /> class
        /// with the assertions to build the filter parameter.
        /// </summary>
        /// <param name="assertion">The <typeparamref name="T"/>.</param>
        internal FilterParameterBuilder(T assertion)
        {
            _assertion = assertion;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Returns the <typeparamref name="T"/> to build filter parameter.
        /// </summary>
        /// <returns>The <typeparamref name="T"/>.</returns>
        public T Should()
        {
            return _assertion;
        }

        #endregion Methods
    }
}