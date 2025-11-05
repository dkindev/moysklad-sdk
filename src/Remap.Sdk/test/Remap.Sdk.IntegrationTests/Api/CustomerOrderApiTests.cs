using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class CustomerOrderApiTests : EntityApiAccessorTests<CustomerOrderApi, CustomerOrder, ApiParameterBuilder<CustomerOrderQuery>, ApiParameterBuilder<CustomerOrdersQuery>>
    {
        #region Ctor

        public CustomerOrderApiTests()
            : base(Pipeline.Instance.Api.Entity.CustomerOrder, async sample =>
            {
                sample.Organization = await Pipeline.Instance.GetDefaultOrganizationAsync();
                sample.Agent = await Pipeline.Instance.GetOrCreateSampleEntityAsync(Pipeline.Instance.Api.Entity.Counterparty);
            })
        {
        }

        #endregion Ctor
    }
}