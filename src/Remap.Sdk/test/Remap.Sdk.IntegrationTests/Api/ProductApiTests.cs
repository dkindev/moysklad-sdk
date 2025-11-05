using System;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class ProductApiTests : EntityApiAccessorTests<ProductApi, Product, ApiParameterBuilder<ProductQuery>, ApiParameterBuilder<ProductsQuery>>
    {
        #region Ctor

        public ProductApiTests() : base(Pipeline.Instance.Api.Entity.Product)
        {
        }

        #endregion Ctor

        #region Methods

        [Test]
        public async Task GetAllAsync_with_query_should_return_status_code_200()
        {
            var response = await _subject.GetAllAsync(query =>
            {
                query.Parameter(p => p.Code).Should().Be("foo").Or.Be("bar");
                query.Parameter(p => p.Name).Should().Be("foo");
                query.Parameter(p => p.Description).Should().Be("foo");
                query.Parameter(p => p.Id).Should().Be(Guid.NewGuid());
                query.Parameter(p => p.PathName).Should().Be("foo");
                query.Parameter(p => p.Volume).Should().BeLessOrEqualTo(0);
                query.Parameter(p => p.Weight).Should().BeGreaterOrEqualTo(0);
                query.Parameter(p => p.IsSerialTrackable).Should().Be(false);
                query.Parameter(p => p.Owner).Should().Be("https://api.moysklad.ru/api/remap/1.2/entity/employee/59a894aa-0ea3-11ea-0a80-006c00081b5b");
                query.Parameter(p => p.Group).Should().Be("https://api.moysklad.ru/api/remap/1.2/entity/group/59a894aa-0ea3-11ea-0a80-006c00081b5b");
                query.Parameter(p => p.Archived).Should().Be(true).Or.Be(false);
                query.Parameter(p => p.Updated).Should()
                    .BeGreaterOrEqualTo(DateTime.Parse("2019-07-10 12:00:00"))
                    .And
                    .BeLessOrEqualTo(DateTime.Parse("2019-07-12 12:00:00"));
                query.Search("foo");
                query.Order().By(p => p.Name);
                query.Expand()
                    .With(p => p.Packs.Uom).And
                    .With(p => p.Images);
                query.Limit(100);
                query.Offset(50);
            });

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetAsync_with_query_should_return_status_code_200()
        {
            var sample = await Pipeline.Instance.GetOrCreateSampleEntityAsync(_subject);
            var response = await _subject.GetAsync(sample.Id.Value, query =>
            {
                query.Expand()
                    .With(p => p.Packs.Uom).And
                    .With(p => p.Country).And
                    .With(p => p.Files).And
                    .With(p => p.ProductFolder).And
                    .With(p => p.Group).And
                    .With(p => p.Owner).And
                    .With(p => p.Supplier).And
                    .With(p => p.Uom).And
                    .With(p => p.Images);
            });

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
            response.Payload.Should().NotBeNull();
            response.Payload.Id.Should().Be(sample.Id.Value);
        }

        [Test]
        public async Task Metadata_GetAsync_should_return_status_code_200()
        {
            var response = await _subject.Metadata.GetAsync();

            response.Should().NotBeNull();
            response.Payload.Should().NotBeNull();
        }

        [Test]
        public async Task Metadata_GetAsync_with_query_should_return_status_code_200()
        {
            var response = await _subject.Metadata.GetAsync(query =>
            {
                query.Expand().With(p => p.Attributes);
            });

            response.Should().NotBeNull();
            response.Payload.Should().NotBeNull();
        }

        [Test]
        public async Task Metadata_GetAttributesAsync_should_return_status_code_200()
        {
            try
            {
                var response = await _subject.Metadata.GetAttributesAsync();

                response.Should().NotBeNull();
                response.Payload.Should().NotBeNull();
            }
            catch (ApiException ex)
            {
                // skip if not available on this tariff
                if (ex.ErrorCode != 403)
                    throw;
            }
        }

        #endregion Methods
    }
}