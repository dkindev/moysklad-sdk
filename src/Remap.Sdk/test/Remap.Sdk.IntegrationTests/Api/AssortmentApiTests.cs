using System;
using System.Linq;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class AssortmentApiTests
    {
        private static AssortmentApi _subject = Pipeline.Instance.Api.Entity.Assortment;

        #region Methods

        [Test]
        public async Task DeleteAsync_should_return_status_code_200()
        {
            var samples = await Pipeline.Instance.CreateSampleEntitiesAsync(Pipeline.Instance.Api.Entity.Product, autoDelete: false);
            var response = await _subject.DeleteAsync(samples.Select(x => new Assortment { Meta = x.Meta }));

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetAllAsync_should_return_status_code_200()
        {
            var response = await _subject.GetAllAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetAllAsync_with_query_should_return_status_code_200()
        {
            var response = await _subject.GetAllAsync(query =>
            {
                query.FilterBy(p => p.Code).Should().Be("foo").Or.Be("bar");
                query.FilterBy(p => p.Name).Should().Be("foo");
                query.FilterBy(p => p.Article).Should().Contains("foo");
                query.FilterBy(p => p.Archived).Should().Be(true).Or.Be(false);
                query.FilterBy(p => p.Updated).Should().BeGreaterOrEqualTo(DateTime.Parse("2019-07-10 12:00:00")).And.BeLessOrEqualTo(DateTime.Parse("2019-07-12 12:00:00"));
                query.FilterBy(p => p.Weighed).Should().Be(true);
                query.FilterBy(p => p.Alcoholic.Type).Should().Be(123);
                query.FilterBy(p => p.StockStore).Should().Be("https://api.moysklad.ru/api/remap/1.2/entity/store/59a894aa-0ea3-11ea-0a80-006c00081b5b");
                query.FilterBy(p => p.StockMode).Should().Be(StockMode.All);
                query.FilterBy(p => p.QuantityMode).Should().Be(QuantityMode.All);
                query.FilterBy(p => p.IsSerialTrackable).Should().Be(false);
                query.Search("foo");
                query.OrderBy(p => p.Name);
                query.Limit(100);
                query.Offset(50);
                query.GroupBy(GroupBy.Consignment);
                query.ExpandBy(m => m.Components).ThenBy(m => m.Components.Assortment);
            });

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetSettingsAsync_should_return_status_code_200()
        {
            var response = await _subject.GetSettingsAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task UpdateSettingsAsync_should_return_status_code_200()
        {
            var response = await _subject.GetSettingsAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);

            response = await _subject.UpdateSettingsAsync(response.Payload);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
        }

        #endregion Methods
    }
}