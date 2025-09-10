using System;
using System.Net;
using System.Net.Http;
using Confiti.MoySklad.Remap.Client;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public abstract class ApiAccessorTests<TApiAccessor>
        where TApiAccessor : ApiAccessor
    {
        #region Fields

        protected MoySkladCredentials _credentials;
        protected TApiAccessor _subject;

        #endregion Fields

        #region Methods

        [OneTimeTearDown]
        public void Clean()
        {
            _subject.Client.Dispose();
            _subject.Client = null;
        }

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
            _subject = CreateApiAccessor(new HttpClient(httpClientHandler, true), _credentials);
        }

        protected virtual TApiAccessor CreateApiAccessor(HttpClient httpClient, MoySkladCredentials credentials)
        {
            return (TApiAccessor)Activator.CreateInstance(typeof(TApiAccessor), httpClient, _credentials);
        }

        #endregion Methods
    }
}