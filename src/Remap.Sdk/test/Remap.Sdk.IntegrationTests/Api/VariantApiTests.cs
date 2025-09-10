using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class VariantApiTests : ApiAccessorTests<VariantApi>
    {
        #region Methods

        [Test]
        public async Task GetMetadataAsync_should_return_status_code_200()
        {
            var response = await _subject.Metadata.GetAsync();
            response.StatusCode.Should().Be(200);
        }

        #endregion Methods
    }
}