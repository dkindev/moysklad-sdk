using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Queries;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class AssortmentApiTests
    {
        #region Fields

        private MoySkladCredentials _credentials;
        private AssortmentApi _subject;

        #endregion Fields

        #region Methods

        #region SetUp

        [OneTimeSetUp]
        public void Init()
        {
            var account = TestAccount.Create();
            _credentials = new MoySkladCredentials()
            {
                Username = account.Username,
                Password = account.Password
            };

            var httpClientHandler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            _subject = new AssortmentApi(new HttpClient(httpClientHandler), _credentials);
        }

        #endregion SetUp

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
                query.Parameter(p => p.Code).Should().Be("foo").Or.Be("bar");
                query.Parameter(p => p.Name).Should().Be("foo");
                query.Parameter(p => p.Article).Should().Contains("foo");
                query.Parameter(p => p.Archived).Should().Be(true).Or.Be(false);
                query.Parameter(p => p.Updated).Should().BeGreaterOrEqualTo(DateTime.Parse("2019-07-10 12:00:00")).And.BeLessOrEqualTo(DateTime.Parse("2019-07-12 12:00:00"));
                query.Parameter(p => p.Weighed).Should().Be(true);
                query.Parameter(p => p.Alcoholic.Type).Should().Be(123);
                query.Parameter(p => p.StockStore).Should().Be("https://api.moysklad.ru/api/remap/1.2/entity/store/59a894aa-0ea3-11ea-0a80-006c00081b5b");
                query.Parameter(p => p.StockMode).Should().Be(StockMode.All);
                query.Parameter(p => p.QuantityMode).Should().Be(QuantityMode.All);
                query.Parameter(p => p.IsSerialTrackable).Should().Be(false);
                query.Search("foo");
                query.Order().By(p => p.Name);
                query.Limit(100);
                query.Offset(50);
                query.GroupBy(GroupBy.Consignment);
                query.Expand().With(m => m.Components).And.With(m => m.Components.Assortment);
            });

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetSettingsAsync_should_return_status_code_200()
        {
            var response = await _subject.GetSettingsAsync();

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task UpdateSettingsAsync_should_return_status_code_200()
        {
            var response = await _subject.GetSettingsAsync();

            response.StatusCode.Should().Be(200);

            response = await _subject.UpdateSettingsAsync(response.Payload);

            response.StatusCode.Should().Be(200);
        }

        #endregion Methods
    }
}