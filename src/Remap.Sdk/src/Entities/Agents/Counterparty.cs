using System;
using System.ComponentModel;
using Confiti.MoySklad.Remap.Client.Json;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an counterparty.
    /// </summary>
    public class Counterparty : MetaEntity, ISynchronizationSupported
    {
        #region Properties

        #region Common

        /// <summary>
        /// Gets or sets the actual address.
        /// </summary>
        public string ActualAddress { get; set; }

        /// <summary>
        /// Gets or sets the actual address full.
        /// </summary>
        public Address ActualAddressFull { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is archived.
        /// </summary>
        public bool? Archived { get; set; }

        /// <summary>
        /// Gets or sets the attribute values.
        /// </summary>
        public AttributeValue[] Attributes { get; set; }

        /// <summary>
        /// Gets or sets the bonus points.
        /// </summary>
        public int? BonusPoints { get; set; }

        /// <summary>
        /// Gets or sets the bonus program.
        /// </summary>
        public BonusProgram BonusProgram { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the company type.
        /// </summary>
        public CompanyType? CompanyType { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been created.
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the discount card number.
        /// </summary>
        public string DiscountCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the external code.
        /// </summary>
        public string ExternalCode { get; set; }

        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the files.
        /// </summary>
        [DefaultValue(EmptyObjectValueProvider.EMPTY_OBJECT_VALUE)]
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PagedEntities<File> Files { get; set; } = new PagedEntities<File>();

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        [DefaultValue(EmptyObjectValueProvider.EMPTY_OBJECT_VALUE)]
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PagedEntities<CounterpartyNote> Notes { get; set; } = new PagedEntities<CounterpartyNote>();

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        [DefaultValue(EmptyObjectValueProvider.EMPTY_OBJECT_VALUE)]
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Employee Owner { get; set; } = new Employee();

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the price type.
        /// </summary>
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets the sales amount.
        /// </summary>
        public double? SalesAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is shared.
        /// </summary>
        public bool? Shared { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public State State { get; set; }

        /// <inheritdoc/>
        public string SyncId { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// </summary>
        public DateTime? Updated { get; set; }

        #endregion Common

        #region Details

        /// <summary>
        /// Gets or sets the accounts.
        /// </summary>
        [DefaultValue(EmptyObjectValueProvider.EMPTY_OBJECT_VALUE)]
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PagedEntities<AgentAccount> Accounts { get; set; } = new PagedEntities<AgentAccount>();

        /// <summary>
        /// Gets or sets the birth date (<see cref="CompanyType.Individual"/> only).
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the certificate date.
        /// </summary>
        public DateTime? CertificateDate { get; set; }

        /// <summary>
        /// Gets or sets the certificate number.
        /// </summary>
        public string CertificateNumber { get; set; }

        /// <summary>
        /// Gets or sets the contact persons.
        /// </summary>
        [DefaultValue(EmptyObjectValueProvider.EMPTY_OBJECT_VALUE)]
        [JsonProperty("contactpersons", NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PagedEntities<ContactPerson> ContactPersons { get; set; } = new PagedEntities<ContactPerson>();

        /// <summary>
        /// Gets or sets the information about a counterparty from Kazakhstan.
        /// </summary>
        [JsonProperty("mod__requisites__kz")]
        public CounterpartyDetailsKZ DetailsKZ { get; set; }

        /// <summary>
        /// Gets or sets the information about a counterparty from Uzbekistan.
        /// </summary>
        [JsonProperty("mod__requisites__uz")]
        public CounterpartyDetailsUZ DetailsUZ { get; set; }

        /// <summary>
        /// Gets or sets the discounts.
        /// </summary>
        public DiscountData[] Discounts { get; set; }

        /// <summary>
        /// Gets or sets the inn.
        /// </summary>
        public string Inn { get; set; }

        /// <summary>
        /// Gets or sets the kpp.
        /// </summary>
        public string Kpp { get; set; }

        /// <summary>
        /// Gets or sets the legal address.
        /// </summary>
        public string LegalAddress { get; set; }

        /// <summary>
        /// Gets or sets the legal address full.
        /// </summary>
        public Address LegalAddressFull { get; set; }

        /// <summary>
        /// Gets or sets the legal first name (<see cref="CompanyType.Individual"/> and <see cref="CompanyType.Entrepreneur"/> only).
        /// </summary>
        public string LegalFirstName { get; set; }

        /// <summary>
        /// Gets or sets the legal last name (<see cref="CompanyType.Individual"/> and <see cref="CompanyType.Entrepreneur"/> only).
        /// </summary>
        public string LegalLastName { get; set; }

        /// <summary>
        /// Gets or sets the legal middle name (<see cref="CompanyType.Individual"/> and <see cref="CompanyType.Entrepreneur"/> only).
        /// </summary>
        public string LegalMiddleName { get; set; }

        /// <summary>
        /// Gets or sets the legal title (<see cref="CompanyType.Legal"/> only). If one of the values ​​for the full name is presented
        /// and is generated automatically based on the received full name of the Counterparty.
        /// </summary>
        public string LegalTitle { get; set; }

        /// <summary>
        /// Gets or sets the ogrn.
        /// </summary>
        public string Ogrn { get; set; }

        /// <summary>
        /// Gets or sets the ogrnip.
        /// </summary>
        public string Ogrnip { get; set; }

        /// <summary>
        /// Gets or sets the okpo.
        /// </summary>
        public string Okpo { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public string[] Tags { get; set; }

        #endregion Details

        #endregion Properties
    }

    /// <summary>
    /// Represents an information about a counterparty from Kazakhstan.
    /// </summary>
    public class CounterpartyDetailsKZ
    {
        #region Properties

        /// <summary>
        /// Gets or sets the BIN.
        /// </summary>
        public string Bin { get; set; }

        /// <summary>
        /// Gets or sets the IIN.
        /// </summary>
        public string Iin { get; set; }

        /// <summary>
        /// Gets or sets the KBe.
        /// </summary>
        public string Kbe { get; set; }

        /// <summary>
        /// Gets or sets the OKED.
        /// </summary>
        public string Oked { get; set; }

        /// <summary>
        /// Gets or sets the VAT certificate date.
        /// </summary>
        public DateTime? VatCertificateDate { get; set; }

        /// <summary>
        /// Gets or sets the VAT certificate number.
        /// </summary>
        public string VatCertificateNumber { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an information about a counterparty from Uzbekistan.
    /// </summary>
    public class CounterpartyDetailsUZ
    {
        #region Properties

        /// <summary>
        /// Gets or sets the certificate date.
        /// </summary>
        public DateTime? CertificateDate { get; set; }

        /// <summary>
        /// Gets or sets the certificate number.
        /// </summary>
        public string CertificateNumber { get; set; }

        /// <summary>
        /// Gets or sets the INN.
        /// </summary>
        public string Inn { get; set; }

        /// <summary>
        /// Gets or sets the OKED.
        /// </summary>
        public string Oked { get; set; }

        /// <summary>
        /// Gets or sets the PINFL.
        /// </summary>
        public string Pinfl { get; set; }

        /// <summary>
        /// Gets or sets the VAT payer registration code.
        /// </summary>
        public string VatPayerRegCode { get; set; }

        #endregion Properties
    }
}