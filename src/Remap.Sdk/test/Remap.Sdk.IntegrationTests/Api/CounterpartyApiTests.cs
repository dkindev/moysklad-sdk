using System;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class CounterpartyApiTests : ApiAccessorTests<CounterpartyApi>
    {
        #region Methods

        [Test]
        public async Task CreateAsync_should_return_status_code_200()
        {
            await PerformWithNewEntityAsync();
        }

        [Test]
        public async Task DeleteAsync_with_counterparty_array_should_return_status_code_200()
        {
            await PerformWithNewEntityAsync(async newCounterparty =>
            {
                var response = await _subject.DeleteAsync(new[] { newCounterparty });

                response.Should().NotBeNull();
                response.StatusCode.Should().Be(200);
            }, false);
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

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetAsync_should_return_status_code_200()
        {
            await PerformWithNewEntityAsync(async newCounterparty =>
            {
                newCounterparty.Id.Should().NotBeNull();

                var response = await _subject.GetAsync(newCounterparty.Id.Value);

                response.Should().NotBeNull();
                response.StatusCode.Should().Be(200);
                response.Payload.Should().NotBeNull();
                response.Payload.Id.Should().Be(newCounterparty.Id.Value);
            });
        }

        [Test]
        public async Task GetAsync_with_query_should_return_status_code_200()
        {
            await PerformWithNewEntityAsync(async newCounterparty =>
            {
                newCounterparty.Id.Should().NotBeNull();

                var response = await _subject.GetAsync(newCounterparty.Id.Value, query =>
                {
                    query.Expand()
                        .With(p => p.Accounts).And
                        .With(p => p.ContactPersons).And
                        .With(p => p.Files).And
                        .With(p => p.Group).And
                        .With(p => p.Notes).And
                        .With(p => p.Owner).And
                        .With(p => p.PriceType).And
                        .With(p => p.State);
                });

                response.Should().NotBeNull();
                response.StatusCode.Should().Be(200);
                response.Payload.Should().NotBeNull();
                response.Payload.Id.Should().Be(newCounterparty.Id.Value);
            });
        }

        [Test]
        public async Task UpdateAsync_should_return_status_code_200()
        {
            await PerformWithNewEntityAsync(async newCounterparty =>
            {
                newCounterparty.Name = $"{newCounterparty.Name} (Updated)";

                var response = await _subject.UpdateAsync(newCounterparty);

                response.Should().NotBeNull();
                response.StatusCode.Should().Be(200);
                response.Payload.Should().NotBeNull();
                response.Payload.Name.Should().Be(newCounterparty.Name);
            });
        }

        #endregion Methods

        #region Utilities

        private async Task PerformWithNewEntityAsync(Func<Counterparty, Task> buildAssertions = null, bool deleteCounterparty = true)
        {
            var counterparty = new Counterparty
            {
                Name = $"Sample Counterparty {Guid.NewGuid()}"
            };

            Counterparty newCounterparty = null;

            try
            {
                var response = await _subject.CreateAsync(counterparty);

                response.Should().NotBeNull();
                response.StatusCode.Should().Be(200);

                newCounterparty = response.Payload;
                newCounterparty.Should().NotBeNull();
                newCounterparty.Name.Should().Be(counterparty.Name);

                if (buildAssertions != null)
                    await buildAssertions(newCounterparty);
            }
            finally
            {
                if (newCounterparty != null && deleteCounterparty)
                {
                    var response = await _subject.DeleteAsync(newCounterparty);

                    response.Should().NotBeNull();
                    response.StatusCode.Should().Be(200);
                }
            }
        }

        #endregion Utilities
    }
}