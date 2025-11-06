using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Queries;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class RetailShiftApiTests
    {
        private static RetailShiftApi _subject = Pipeline.Instance.Api.Entity.RetailShift;

        #region Methods

        [Test]
        public async Task GetAllAsync_should_return_status_code_200()
        {
            var response = await _subject.GetAllAsync();
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetAllAsync_with_query_should_return_status_code_200()
        {
            var response = await _subject.GetAllAsync(query =>
            {
                query.OrderBy("moment", OrderBy.Desc);
                query.Limit(100);
            });

            response.StatusCode.Should().Be(200);
        }

        #endregion Methods
    }
}