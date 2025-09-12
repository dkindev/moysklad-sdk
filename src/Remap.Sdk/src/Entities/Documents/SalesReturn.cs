using System;
using Confiti.MoySklad.Remap.Client.Json;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an sales return.
    /// </summary>
    public class SalesReturn : Document
    {
        // todo
        // factureOut;

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
        /// Gets or sets the contract.
        /// </summary>
        /// <value>The contract.</value>
        public Contract Contract { get; set; }

        /// <summary>
        /// Gets or sets the delivery planned date.
        /// </summary>
        /// <value>The date when the delivery planned date.</value>
        public DateTime? DeliveryPlannedMoment { get; set; }

        /// <summary>
        /// Gets or sets the demand.
        /// </summary>
        /// <value>The demand.</value>
        public Demand Demand { get; set; }

        /// <summary>
        /// Gets or sets the invoiced sum.
        /// </summary>
        /// <value>The invoiced sum.</value>
        public long? InvoicedSum { get; set; }

        /// <summary>
        /// Gets or sets the invoices out.
        /// </summary>
        /// <value>The invoices out.</value>
        public InvoiceOut[] InvoicesOut { get; set; }

        /// <summary>
        /// Gets or sets the payments.
        /// </summary>
        /// <value>The payments.</value>
        public Loss[] Losses { get; set; }

        /// <summary>
        /// Gets or sets the organization account.
        /// </summary>
        /// <value>The organization account.</value>
        public AgentAccount OrganizationAccount { get; set; }

        /// <summary>
        /// Gets or sets the payed sum.
        /// </summary>
        /// <value>The payed sum.</value>
        public long? PayedSum { get; set; }

        /// <summary>
        /// Gets or sets the payments.
        /// </summary>
        /// <value>The payments.</value>
        public PaymentDocument[] Payments { get; set; }

        /// <summary>
        /// Gets or sets the positions.
        /// </summary>
        /// <value>The positions.</value>
        [EmptyObjectValue]
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PagedEntities<SalesReturnPosition> Positions { get; set; } = new PagedEntities<SalesReturnPosition>();

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
        /// Gets or sets the reserved sum.
        /// </summary>
        /// <value>The reserved sum.</value>
        public long? ReservedSum { get; set; }

        /// <summary>
        /// Gets or sets the sales channel.
        /// </summary>
        /// <value>The sales channel.</value>
        public SalesChannel SalesChannel { get; set; }

        /// <summary>
        /// Gets or sets the shipped sum.
        /// </summary>
        /// <value>The shipped sum.</value>
        public long? ShippedSum { get; set; }

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