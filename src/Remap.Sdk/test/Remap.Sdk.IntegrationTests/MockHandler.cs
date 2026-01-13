using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.IntegrationTests
{
    public class MockHandler : DelegatingHandler
    {
        #region Fields

        private readonly Func<HttpRequestMessage, Task<HttpResponseMessage>> _interceptBeforeSend;

        #endregion Fields

        #region Ctor

        public MockHandler(HttpMessageHandler next, Func<HttpRequestMessage, Task<HttpResponseMessage>> interceptBeforeSend)
            : base(next)
        {
            _interceptBeforeSend = interceptBeforeSend;
        }

        #endregion Ctor

        #region Methods

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await _interceptBeforeSend(request);
            if (response != null)
                return response;

            return await base.SendAsync(request, cancellationToken);
        }

        #endregion Methods
    }
}