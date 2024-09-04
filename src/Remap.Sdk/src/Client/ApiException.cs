using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents a MoySklad API Exception.
    /// </summary>
    [Serializable]
    public sealed class ApiException : Exception, ISerializable
    {
        private const string C_ERROR_CODE = "ErrorCode";
        private const string C_ERRORS = "Errors";
        private const string C_HEADERS = "Headers";

        #region Fields

        private readonly int _errorCode;
        private readonly ApiError[] _errors;
        private readonly Dictionary<string, string> _headers;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the error code (HTTP status code).
        /// </summary>
        /// <value>The error code (HTTP status code).</value>
        public int ErrorCode => _errorCode;

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>The errors.</value>
        public ApiError[] Errors => _errors;

        /// <summary>
        /// Gets the HTTP headers.
        /// </summary>
        /// <value>The HTTP headers</value>
        public Dictionary<string, string> Headers => _headers;

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ApiException(string message, Exception innerException = null)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="errorCode">The HTTP status code.</param>
        /// <param name="message">The error message.</param>
        /// <param name="headers">The HTTP headers.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="innerException">The inner exception.</param>
        public ApiException(int errorCode, string message, Dictionary<string, string> headers, ApiError[] errors, Exception innerException = null)
            : base(message, innerException)
        {
            _errorCode = errorCode;
            _headers = headers;
            _errors = errors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="errorCode">The HTTP status code.</param>
        /// <param name="message">The error message.</param>
        public ApiException(int errorCode, string message)
            : base(message)
        {
            _errorCode = errorCode;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        private ApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _errorCode = (int)info.GetValue(C_ERROR_CODE, typeof(int));
            _headers = (Dictionary<string, string>)info.GetValue(C_HEADERS, typeof(Dictionary<string, string>));
            _errors = (ApiError[])info.GetValue(C_ERRORS, typeof(ApiError[]));
        }

        #endregion Ctor

        #region Methods

        /// <inheritdoc/>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(C_ERROR_CODE, _errorCode);

            if (_headers != null)
                info.AddValue(C_HEADERS, _headers);

            if (_errors != null)
                info.AddValue(C_ERRORS, _errors);

            base.GetObjectData(info, context);
        }

        #endregion Methods
    }
}