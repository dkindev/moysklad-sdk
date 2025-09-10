using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class CounterpartyApiTests
    {
        #region Fields

        private MoySkladCredentials _credentials;
        private CounterpartyApi _subject;

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
            _subject = new CounterpartyApi(new HttpClient(httpClientHandler), _credentials);
        }

        #endregion SetUp

        [Test]
        public async Task CreateAsync_should_return_status_code_200()
        {
            var counterparty = await CreateCounterpartyAsync();

            try
            {
                counterparty.Should().NotBeNull();
            }
            finally
            {
                await DeleteCounterpartyAsync(counterparty);
            }
        }

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
                query.Parameter(p => p.AccountId).Should().Be(Guid.NewGuid());
                query.Parameter(p => p.ActualAddress).Should().Be("foo");
                query.Parameter(p => p.Description).Should().Be("foo");
                query.Parameter(p => p.DetailsKZ.Oked).Should().Be("foo");
                query.Parameter(p => p.DetailsKZ.Bin).Should().Be("foo");
                query.Parameter(p => p.DetailsKZ.Iin).Should().Be("foo");
                query.Parameter(p => p.DetailsKZ.Kbe).Should().Be("foo");
                query.Parameter(p => p.DetailsKZ.VatCertificateNumber).Should().Be("foo");
                query.Parameter(p => p.DetailsKZ.VatCertificateDate).Should().BeGreaterOrEqualTo(DateTime.Parse("2019-07-10 12:00:00"));
                query.Parameter(p => p.DetailsUZ.CertificateDate).Should().BeGreaterOrEqualTo(DateTime.Parse("2019-07-10 12:00:00"));
                query.Parameter(p => p.DetailsUZ.CertificateNumber).Should().Be("foo");
                query.Parameter(p => p.DetailsUZ.Inn).Should().Be("foo");
                query.Parameter(p => p.DetailsUZ.Oked).Should().Be("foo");
                query.Parameter(p => p.DetailsUZ.Pinfl).Should().Be("foo");
                query.Parameter(p => p.DetailsUZ.VatPayerRegCode).Should().Be("foo");
                query.Parameter(p => p.CompanyType).Should().Be(CompanyType.Legal);
                query.Parameter(p => p.Archived).Should().Be(true).Or.Be(false);
                query.Parameter(p => p.Created).Should().BeGreaterOrEqualTo(DateTime.Parse("2019-07-10 12:00:00")).And.BeLessOrEqualTo(DateTime.Parse("2019-07-12 12:00:00"));
                query.Parameter(p => p.Updated).Should().BeGreaterOrEqualTo(DateTime.Parse("2019-07-10 12:00:00")).And.BeLessOrEqualTo(DateTime.Parse("2019-07-12 12:00:00"));
                query.Search("foo");
                query.Order().By(p => p.Name);
                query.Expand().With(p => p.Notes).And.With(p => p.ContactPersons);
                query.Limit(100);
                query.Offset(50);
            });
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetAsync_should_return_status_code_200()
        {
            var counterparty = await CreateCounterpartyAsync();

            try
            {
                counterparty.Should().NotBeNull();
                counterparty.Id.Should().NotBeNull();

                var response = await _subject.GetAsync(counterparty.Id.Value);

                response.StatusCode.Should().Be(200);
                response.Payload.Should().NotBeNull();
                response.Payload.Id.Should().Be(counterparty.Id.Value);
            }
            finally
            {
                await DeleteCounterpartyAsync(counterparty);
            }
        }

        [Test]
        public async Task UpdateAsync_should_return_status_code_200()
        {
            var counterparty = await CreateCounterpartyAsync();

            try
            {
                counterparty.Should().NotBeNull();

                counterparty.Name = "Sample Counterparty (Updated)";

                var response = await _subject.UpdateAsync(counterparty);

                response.StatusCode.Should().Be(200);
                response.Payload.Should().NotBeNull();
                response.Payload.Name.Should().Be(counterparty.Name);
            }
            finally
            {
                await DeleteCounterpartyAsync(counterparty);
            }
        }

        #endregion Methods

        #region Utilities

        private async Task<Counterparty> CreateCounterpartyAsync()
        {
            var response = await _subject.CreateAsync(new Counterparty
            {
                Name = "Sample Counterparty"
            });

            response.StatusCode.Should().Be(200);

            return response.Payload;
        }

        private async Task DeleteCounterpartyAsync(Counterparty counterparty)
        {
            var response = await _subject.DeleteAsync(counterparty);
            response.StatusCode.Should().Be(200);
        }

        #endregion Utilities
    }
}