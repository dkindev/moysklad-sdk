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
                query.Parameter(x => x.Variant).Should()
                    .Be("https://api.moysklad.ru/api/remap/1.2/entity/variant/14553caa-2cb2-11e6-8a84-bae500000026")
                    .Or
                    .Be("https://api.moysklad.ru/api/remap/1.2/entity/variant/14553caa-2cb2-11e6-8a84-bae500000030");
                query.Parameter(x => x.Store).Should()
                    .Be("https://api.moysklad.ru/api/remap/1.2/entity/store/14553caa-2cb2-11e6-8a84-bae500000026")
                    .Or
                    .Be("https://api.moysklad.ru/api/remap/1.2/entity/store/14553caa-2cb2-11e6-8a84-bae500000030");
                query.Parameter(x => x.Supplier).Should()
                    .Be("https://api.moysklad.ru/api/remap/1.2/entity/counterparty/14553caa-2cb2-11e6-8a84-bae500000026")
                    .Or
                    .Be("https://api.moysklad.ru/api/remap/1.2/entity/counterparty/14553caa-2cb2-11e6-8a84-bae500000030");
                query.Parameter(x => x.Archived).Should().Be(true).Or.Be(false);
                query.Parameter(x => x.WithSubFolders).Should().Be(true).Or.Be(false);
                query.Parameter(x => x.ReserveOnly).Should().Be(true);
                query.Parameter(x => x.InTransitOnly).Should().Be(false);
                query.Parameter(x => x.SoldByWeight).Should().Be(false);
                query.Parameter(x => x.StockDaysFrom).Should().Be(1);
                query.Parameter(x => x.StockDaysTo).Should().Be(5);
                query.Parameter(x => x.Moment).Should().Be(DateTime.Now);
                query.Parameter(x => x.QuantityMode).Should().Be(QuantityMode.PositiveOnly);
                query.Parameter(x => x.StockMode).Should().Be(StockMode.PositiveOnly);
                query.Parameter(x => x.Search).Should().Be("foo").Or.Be("bar");

                query.Order().By(x => x.Name);

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
                query.Parameter(p => p.StoreId).Should().Be(supply.Store.GetId().Value);
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
            return Pipeline.Instance.CreateSampleEntityAsync(
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