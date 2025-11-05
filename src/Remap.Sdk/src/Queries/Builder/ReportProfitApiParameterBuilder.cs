using System;
using System.Collections.Generic;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an helper class to build API parameters for <see cref="ReportProfit"/> query.
    /// </summary>
    public class ReportProfitApiParameterBuilder : ApiParameterBuilder
    {
        #region Fields

        private string _momentFrom;
        private string _momentTo;

        #endregion Fields

        #region Methods

        /// <inheritdoc/>
        public override Dictionary<string, string> Build()
        {
            var query = base.Build();

            if (!string.IsNullOrWhiteSpace(_momentFrom))
                query["momentFrom"] = _momentFrom;

            if (!string.IsNullOrWhiteSpace(_momentTo))
                query["momentTo"] = _momentTo;

            return query;
        }

        /// <summary>
        /// Builds the moment from API parameter.
        /// </summary>
        /// <param name="value">The moment from.</param>
        /// <param name="format">The date time format.</param>
        public void MomentFrom(DateTime value, string format = ApiDefaults.DEFAULT_DATETIME_FORMAT)
        {
            _momentFrom = value.ToString(format);
        }

        /// <summary>
        /// Builds the moment to API parameter.
        /// </summary>
        /// <param name="value">The moment to.</param>
        /// <param name="format">The date time format.</param>
        public void MomentTo(DateTime value, string format = ApiDefaults.DEFAULT_DATETIME_FORMAT)
        {
            _momentTo = value.ToString(format);
        }

        #endregion Methods
    }
}