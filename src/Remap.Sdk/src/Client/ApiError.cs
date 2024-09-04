using System;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents a API error.
    /// </summary>
    [Serializable]
    public sealed class ApiError
    {
        #region Properties

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <remarks>
        /// If the field contains nothing, see the HTTP status code.
        /// </remarks>
        /// <value>The error code.</value>
        public int? Code { get; set; }

        /// <summary>
        /// Gets or sets the column(in request body) on which the error occurred.
        /// </summary>
        /// <value>The column(in request body) on which the error occurred.</value>
        public int Column { get; set; }

        /// <summary>
        /// Gets or sets the error title.
        /// </summary>
        /// <value>The error title.</value>
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets the line(in request body) on which the error occurred.
        /// </summary>
        /// <value>The line(in request body) on which the error occurred.</value>
        public int Line { get; set; }

        /// <summary>
        /// Gets or sets the link to the full description of the error.
        /// </summary>
        /// <value>The link to the full description of the error.</value>
        public string MoreInfo { get; set; }

        /// <summary>
        /// Gets or sets the parameter on which the error occurred.
        /// </summary>
        /// <value>The parameter on which the error occurred.</value>
        public string Parameter { get; set; }

        #endregion Properties
    }
}