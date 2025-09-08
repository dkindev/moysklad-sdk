using System.ComponentModel;
using Confiti.MoySklad.Remap.Client.Json;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an retail sales return.
    /// </summary>
    public class RetailSalesReturn : Document
    {
        // todo
        //private RetailShift retailShift;
        //private RetailStore retailStore;

        #region Properties

        /// <summary>
        /// Gets or sets the agent.
        /// </summary>
        /// <value>The agent.</value>
        public Counterparty Agent { get; set; }

        /// <summary>
        /// Gets or sets the agent account.
        /// </summary>
        /// <value>The agent account.</value>
        public AgentAccount AgentAccount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the document is applicable.
        /// </summary>
        /// <value>The value indicating whether to the document is applicable.</value>
        public bool? Applicable { get; set; }

        /// <summary>
        /// Gets or sets the attribute values.
        /// </summary>
        /// <value>The attribute values.</value>
        public AttributeValue[] Attributes { get; set; }

        /// <summary>
        /// Gets or sets the cash sum.
        /// </summary>
        /// <value>The cash sum.</value>
        public long? CashSum { get; set; }

        /// <summary>
        /// Gets or sets the contract.
        /// </summary>
        /// <value>The contract.</value>
        public Contract Contract { get; set; }

        /// <summary>
        /// Gets or sets the retail demand.
        /// </summary>
        /// <value>The retail demand.</value>
        public RetailDemand Demand { get; set; }

        /// <summary>
        /// Gets or sets the 'no cash' sum.
        /// </summary>
        /// <value>The 'no cash' sum.</value>
        public long? NoCashSum { get; set; }

        /// <summary>
        /// Gets or sets the organization account.
        /// </summary>
        /// <value>The organization account.</value>
        public AgentAccount OrganizationAccount { get; set; }

        /// <summary>
        /// Gets or sets the positions.
        /// </summary>
        /// <value>The positions.</value>
        [DefaultValue(EmptyObjectValueProvider.EMPTY_OBJECT_VALUE)]
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PagedEntities<RetailSalesPosition> Positions { get; set; } = new PagedEntities<RetailSalesPosition>();

        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        public Project Project { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>The rate.</value>
        public Rate Rate { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public State State { get; set; }

        /// <summary>
        /// Gets or sets the store.
        /// </summary>
        /// <value>The store.</value>
        public Store Store { get; set; }

        /// <summary>
        /// Gets or sets the total sum.
        /// </summary>
        /// <value>The total sum.</value>
        public long? Sum { get; set; }

        /// <summary>
        /// Gets or sets the tax system.
        /// </summary>
        /// <value>The tax system.</value>
        public DocumentTaxSystem? TaxSystem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the vat is enabled.
        /// </summary>
        /// <value>The value indicating whether to the vat is enabled.</value>
        public bool? VatEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the vat is included.
        /// </summary>
        /// <value>The value indicating whether to the vat is included.</value>
        public bool? VatIncluded { get; set; }

        /// <summary>
        /// Gets or sets the vat sum.
        /// </summary>
        /// <value>The vat sum.</value>
        public long? VatSum { get; set; }

        #endregion Properties
    }
}