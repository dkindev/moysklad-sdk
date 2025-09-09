using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class VariantApiTests
    {
        #region Fields

        private MoySkladCredentials _credentials;
        private VariantApi _subject;

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
            _subject = new VariantApi(new HttpClient(httpClientHandler), _credentials);
        }

        #endregion SetUp

        [Test]
        public async Task GetMetadataAsync_should_return_status_code_200()
        {
            var response = await _subject.Metadata.GetAsync();
            response.StatusCode.Should().Be(200);
        }

        #endregion Methods
    }
}