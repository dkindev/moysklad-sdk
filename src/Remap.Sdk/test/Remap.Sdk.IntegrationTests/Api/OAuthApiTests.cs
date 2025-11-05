using System;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class OAuthApiTests
    {
        private static OAuthApi _subject = Pipeline.Instance.Api.Entity.OAuth;

        #region Methods

        [Test]
        public async Task GetAsync_should_return_access_token()
        {
            var response = await _subject.GetAsync();

            response.Payload.AccessToken.Should().NotBeNullOrWhiteSpace();
        }

        [Test]
        public async Task GetAsync_should_return_status_code_200_or_201()
        {
            var response = await _subject.GetAsync();

            response.StatusCode.Should().BeOneOf(200, 201);
        }

        [Test]
        public async Task GetAsync_with_invalid_password_should_throw_api_exception()
        {
            var oldPassword = _subject.Credentials.Password;

            _subject.Credentials.Password = null;

            Func<Task> getAccessToken = () => _subject.GetAsync();
            var apiException = await getAccessToken.Should().ThrowAsync<ApiException>();

            try
            {
                apiException.And.ErrorCode.Should().Be(401);
            }
            finally
            {
                _subject.Credentials.Password = oldPassword;
            }
        }

        #endregion Methods
    }
}