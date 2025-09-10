using System;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class ReportProfitApiTests : ApiAccessorTests<ReportProfitApi>
    {
        #region Methods

        [Test]
        public async Task GetByCounterpartyAsync_should_return_status_code_200()
        {
            var response = await _subject.GetByCounterpartyAsync(query =>
            {
                query.Limit(100);
                query.MomentFrom(DateTime.Today.AddDays(-7));
                query.MomentTo(DateTime.Now);
            });

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetByEmployeeAsync_should_return_status_code_200()
        {
            var response = await _subject.GetByEmployeeAsync(query =>
            {
                query.Limit(100);
                query.MomentFrom(DateTime.Today.AddDays(-7));
                query.MomentTo(DateTime.Now);
            });

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetByProductAsync_should_return_status_code_200()
        {
            var response = await _subject.GetByProductAsync(query =>
            {
                query.Limit(100);
                query.MomentFrom(DateTime.Today.AddDays(-7));
                query.MomentTo(DateTime.Now);
            });

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetBySalesChannelAsync_should_return_status_code_200()
        {
            var response = await _subject.GetBySalesChannelAsync(query =>
            {
                query.Limit(100);
                query.MomentFrom(DateTime.Today.AddDays(-7));
                query.MomentTo(DateTime.Now);
            });

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetByVariantAsync_should_return_status_code_200()
        {
            var response = await _subject.GetByVariantAsync(query =>
            {
                query.Limit(100);
                query.MomentFrom(DateTime.Today.AddDays(-7));
                query.MomentTo(DateTime.Now);
            });

            response.StatusCode.Should().Be(200);
        }

        #endregion Methods
    }
}