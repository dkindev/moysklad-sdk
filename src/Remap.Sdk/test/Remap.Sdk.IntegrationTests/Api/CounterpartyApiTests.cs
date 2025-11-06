using System;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class CounterpartyApiTests : EntityApiAccessorTests<CounterpartyApi, Counterparty, ApiParameterBuilder<CounterpartyQuery>, ApiParameterBuilder<CounterpartiesQuery>>
    {
        #region Ctor

        public CounterpartyApiTests() : base(Pipeline.Instance.Api.Entity.Counterparty)
        {
        }

        #endregion Ctor

        #region Methods

        [Test]
        public async Task GetAllAsync_with_query_should_return_status_code_200()
        {
            var response = await _subject.GetAllAsync(query =>
            {
                query.FilterBy(p => p.Code).Should().Be("foo").Or.Be("bar");
                query.FilterBy(p => p.Name).Should().Be("foo");
                query.FilterBy(p => p.AccountId).Should().Be(Guid.NewGuid());
                query.FilterBy(p => p.ActualAddress).Should().Be("foo");
                query.FilterBy(p => p.Description).Should().Be("foo");
                query.FilterBy(p => p.DetailsKZ.Oked).Should().Be("foo");
                query.FilterBy(p => p.DetailsKZ.Bin).Should().Be("foo");
                query.FilterBy(p => p.DetailsKZ.Iin).Should().Be("foo");
                query.FilterBy(p => p.DetailsKZ.Kbe).Should().Be("foo");
                query.FilterBy(p => p.DetailsKZ.VatCertificateNumber).Should().Be("foo");
                query.FilterBy(p => p.DetailsKZ.VatCertificateDate).Should().BeGreaterOrEqualTo(DateTime.Parse("2019-07-10 12:00:00"));
                query.FilterBy(p => p.DetailsUZ.CertificateDate).Should().BeGreaterOrEqualTo(DateTime.Parse("2019-07-10 12:00:00"));
                query.FilterBy(p => p.DetailsUZ.CertificateNumber).Should().Be("foo");
                query.FilterBy(p => p.DetailsUZ.Inn).Should().Be("foo");
                query.FilterBy(p => p.DetailsUZ.Oked).Should().Be("foo");
                query.FilterBy(p => p.DetailsUZ.Pinfl).Should().Be("foo");
                query.FilterBy(p => p.DetailsUZ.VatPayerRegCode).Should().Be("foo");
                query.FilterBy(p => p.CompanyType).Should().Be(CompanyType.Legal);
                query.FilterBy(p => p.Archived).Should().Be(true).Or.Be(false);
                query.FilterBy(p => p.Created).Should().BeGreaterOrEqualTo(DateTime.Parse("2019-07-10 12:00:00")).And.BeLessOrEqualTo(DateTime.Parse("2019-07-12 12:00:00"));
                query.FilterBy(p => p.Updated).Should().BeGreaterOrEqualTo(DateTime.Parse("2019-07-10 12:00:00")).And.BeLessOrEqualTo(DateTime.Parse("2019-07-12 12:00:00"));
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
        public async Task GetAsync_with_query_should_return_status_code_200()
        {
            var sample = await Pipeline.Instance.GetOrCreateSampleEntityAsync(_subject);
            var response = await _subject.GetAsync(sample.Id.Value, query =>
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
            response.Payload.Id.Should().Be(sample.Id.Value);
        }

        #endregion Methods
    }
}