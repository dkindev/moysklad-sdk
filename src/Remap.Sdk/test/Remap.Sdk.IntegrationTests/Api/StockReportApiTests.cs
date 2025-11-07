using System;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class StockReportApiTests
    {
        private static StockReportApi _subject = Pipeline.Instance.Api.Report.Stock;

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
                query.FilterBy(x => x.Variant).Should()
                    .Be("https://api.moysklad.ru/api/remap/1.2/entity/variant/14553caa-2cb2-11e6-8a84-bae500000026")
                    .Or
                    .Be("https://api.moysklad.ru/api/remap/1.2/entity/variant/14553caa-2cb2-11e6-8a84-bae500000030");
                query.FilterBy(x => x.Store).Should()
                    .Be("https://api.moysklad.ru/api/remap/1.2/entity/store/14553caa-2cb2-11e6-8a84-bae500000026")
                    .Or
                    .Be("https://api.moysklad.ru/api/remap/1.2/entity/store/14553caa-2cb2-11e6-8a84-bae500000030");
                query.FilterBy(x => x.Supplier).Should()
                    .Be("https://api.moysklad.ru/api/remap/1.2/entity/counterparty/14553caa-2cb2-11e6-8a84-bae500000026")
                    .Or
                    .Be("https://api.moysklad.ru/api/remap/1.2/entity/counterparty/14553caa-2cb2-11e6-8a84-bae500000030");
                query.FilterBy(x => x.Archived).Should().Be(true).Or.Be(false);
                query.FilterBy(x => x.ReserveOnly).Should().Be(true);
                query.FilterBy(x => x.InTransitOnly).Should().Be(false);
                query.FilterBy(x => x.SoldByWeight).Should().Be(false);
                query.FilterBy(x => x.StockDaysFrom).Should().Be(1);
                query.FilterBy(x => x.StockDaysTo).Should().Be(5);
                query.FilterBy(x => x.Moment).Should().Be(DateTime.Now);
                query.FilterBy(x => x.QuantityMode).Should().Be(QuantityMode.PositiveOnly);
                query.FilterBy(x => x.StockMode).Should().Be(StockMode.PositiveOnly);
                query.FilterBy(x => x.Search).Should().Be("foo").Or.Be("bar");
                query.OrderBy(x => x.Name);
                query.GroupBy(GroupBy.Consignment);
            });
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetByOperationAsync_should_return_status_code_200()
        {
            var supply = await GetOrCreateSupplyAsync();
            supply.Should().NotBeNull();
            supply.Id.Should().NotBeNull();

            var response = await _subject.GetByOperationAsync(supply.Id.Value);
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetByStoreAsync_should_return_status_code_200()
        {
            var response = await _subject.GetByStoreAsync();
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetCurrentAsync_should_return_status_code_200()
        {
            var response = await _subject.GetCurrentAsync();
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetCurrentBySlotAsync_should_return_status_code_200()
        {
            var supply = await GetOrCreateSupplyAsync();
            var response = await _subject.GetCurrentBySlotAsync(query =>
            {
                query.FilterBy(p => p.StoreId).Should().Be(supply.Store.GetId().Value);
            });
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetCurrentByStoreAsync_should_return_status_code_200()
        {
            var response = await _subject.GetCurrentByStoreAsync();
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetCurrentByStoreAsync_with_query_should_return_status_code_200()
        {
            var response = await _subject.GetCurrentByStoreAsync(query => query.WithRecalculate(true));
            response.StatusCode.Should().Be(200);
        }

        #endregion Methods

        #region Utilities

        private Task<Supply> GetOrCreateSupplyAsync()
        {
            return Pipeline.Instance.GetOrCreateSampleEntityAsync(
                Pipeline.Instance.Api.Entity.Supply,
                async entity =>
                {
                    entity.Organization = await Pipeline.Instance.GetDefaultOrganizationAsync();
                    entity.Agent = await Pipeline.Instance.GetOrCreateSampleEntityAsync(Pipeline.Instance.Api.Entity.Counterparty);
                    entity.Store = await Pipeline.Instance.GetOrCreateSampleEntityAsync(Pipeline.Instance.Api.Entity.Store);
                    entity.Positions.Rows = new[]
                    {
                        new SupplyPosition
                        {
                            Quantity = 10,
                            Price = 100,
                            Overhead = 5,
                            Assortment = await Pipeline.Instance.CreateSampleEntityAsync(Pipeline.Instance.Api.Entity.Product)
                        }
                    };
                }
            );
        }

        #endregion Utilities
    }
}