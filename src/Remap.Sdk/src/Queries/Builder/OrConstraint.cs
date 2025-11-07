namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an object to chain another object into a call chain.
    /// </summary>
    /// <typeparam name="T">The type of the constraint.</typeparam>
    public class OrConstraint<T>
    {
        /// <summary>
        /// Creates a new instance of the <see cref="OrConstraint{T}" /> class
        /// with parent constraint.
        /// </summary>
        /// <param name="parentConstraint">The parent constraint.</param>
        public OrConstraint(T parentConstraint)
        {
            Or = parentConstraint;
        }

        /// <summary>
        /// Gets the parent constraint.
        /// </summary>
        public T Or { get; }
    }
}