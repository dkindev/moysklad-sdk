using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class CustomerOrderApiTests : ApiAccessorTests<CustomerOrderApi>
    {
        #region Methods

        [Test]
        public async Task GetAllAsync_should_return_status_code_200()
        {
            var response = await _subject.GetAllAsync();
            response.StatusCode.Should().Be(200);
        }

        #endregion Methods
    }
}