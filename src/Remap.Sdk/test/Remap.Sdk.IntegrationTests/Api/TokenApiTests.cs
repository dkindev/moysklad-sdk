using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class TokenApiTests
    {
        private static TokenApi _subject = Pipeline.Instance.Api.Security.Token;

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
        public async Task GetAsync_with_expicit_basic_credentials_should_call_with_new_credentials()
        {
            var newCredentials = new MoySkladCredentials
            {
                Username = "foo",
                Password = "bar",
            };

            AuthenticationHeaderValue authHeader = null;

            await Pipeline.InterceptBeforeSendingAsync(_subject, 
                api => api.GetAsync(newCredentials),
                request =>
                {
                    authHeader = request.Headers.Authorization;
                    return Task.FromResult(new HttpResponseMessage());
                }
            );

            authHeader.Scheme.Should().Be("Basic");

            var credentialsData = Encoding.UTF8.GetBytes($"{newCredentials.Username}:{newCredentials.Password}");
            var convertedCredentialsData = Convert.ToBase64String(credentialsData);
            authHeader.Parameter.Should().Be(convertedCredentialsData);
        }

        [Test]
        public async Task GetAsync_with_invalid_password_should_throw_exception()
        {
            var oldPassword = _subject.Credentials.Password;

            _subject.Credentials.Password = null;

            Func<Task> getAccessToken = () => _subject.GetAsync();
            await getAccessToken.Should().ThrowAsync<MoySkladException>();

            _subject.Credentials.Password = oldPassword;
        }

        #endregion Methods
    }
}