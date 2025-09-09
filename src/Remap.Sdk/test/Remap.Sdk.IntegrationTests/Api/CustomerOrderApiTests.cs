using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class CustomerOrderApiTests
    {
        #region Fields

        private MoySkladCredentials _credentials;
        private CustomerOrderApi _subject;

        #endregion Fields

        #region Methods

        #region SetUp

        [SetUp]
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
            _subject = new CustomerOrderApi(new HttpClient(httpClientHandler), _credentials);
        }

        #endregion SetUp

        [Test]
        public async Task GetAllAsync_should_return_status_code_200()
        {
            var response = await _subject.GetAllAsync();
            response.StatusCode.Should().Be(200);
        }

        #endregion Methods
    }
}