using System;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an query for list of <see cref="Counterparty"/>.
    /// See also: https://dev.moysklad.ru/doc/api/remap/1.2/dictionaries/#suschnosti-kontragent-kontragenty.
    /// </summary>
    public class CounterpartiesQuery : CounterpartyQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the account ID.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(overriddenOperators: new[] { "=", "!=" })]
        [AllowOrder]
        [Parameter("accountId")]
        public Guid AccountId { get; set; }

        /// <summary>
        /// Gets or sets the actual address.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("actualAddress")]
        public string ActualAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is archived.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("archived")]
        public bool Archived { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the company type.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [Parameter("companyType")]
        public CompanyType CompanyType { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been created.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the information about a counterparty from Kazakhstan.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(allowNesting: true)]
        [Parameter("mod__requisites__kz")]
        public CounterpartyDetailsKZQuery DetailsKZ { get; set; }

        /// <summary>
        /// Gets or sets the information about a counterparty from Uzbekistan.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(allowNesting: true)]
        [Parameter("mod__requisites__uz")]
        public CounterpartyDetailsUZQuery DetailsUZ { get; set; }

        /// <summary>
        /// Gets or sets the discount card number.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("discountCardNumber")]
        public string DiscountCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the external code.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("externalCode")]
        public string ExternalCode { get; set; }

        /// <summary>
        /// Gets or sets the fax.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("fax")]
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the ID.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the inn.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("inn")]
        public string Inn { get; set; }

        /// <summary>
        /// Gets or sets the kpp.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("kpp")]
        public string Kpp { get; set; }

        /// <summary>
        /// Gets or sets the legal address.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("legalAddress")]
        public string LegalAddress { get; set; }

        /// <summary>
        /// Gets or sets the legal title (<see cref="CompanyType.Legal"/> only). If one of the values ​​for the full name is presented
        /// and is generated automatically based on the received full name of the Counterparty.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("legalTitle")]
        public string LegalTitle { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(allowNull: false)]
        [AllowOrder]
        [Parameter("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is shared.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(allowContinueConstraint: false)]
        [AllowOrder]
        [Parameter("shared")]
        public bool Shared { get; set; }

        /// <summary>
        /// Gets or sets the synchronization id.
        /// <see cref="FilterAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(overriddenOperators: new[] { "=", "!=" })]
        [Parameter("syncId")]
        public string SyncId { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(overriddenOperators: new[] { "=", "!=" })]
        [AllowOrder]
        [Parameter("tags")]
        public string Tags { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("updated")]
        public DateTime Updated { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an query for <see cref="CounterpartyDetailsKZ"/>.
    /// </summary>
    public class CounterpartyDetailsKZQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the BIN.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("bin")]
        public string Bin { get; set; }

        /// <summary>
        /// Gets or sets the IIN.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("iin")]
        public string Iin { get; set; }

        /// <summary>
        /// Gets or sets the KBe.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("kbe")]
        public string Kbe { get; set; }

        /// <summary>
        /// Gets or sets the OKED.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("oked")]
        public string Oked { get; set; }

        /// <summary>
        /// Gets or sets the VAT certificate date.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("vatCertificateDate")]
        public DateTime VatCertificateDate { get; set; }

        /// <summary>
        /// Gets or sets the VAT certificate number.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("vatCertificateNumber")]
        public string VatCertificateNumber { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Represents an query for <see cref="CounterpartyDetailsUZ"/>.
    /// </summary>
    public class CounterpartyDetailsUZQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the certificate date.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("certificateDate")]
        public DateTime CertificateDate { get; set; }

        /// <summary>
        /// Gets or sets the certificate number.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("certificateNumber")]
        public string CertificateNumber { get; set; }

        /// <summary>
        /// Gets or sets the INN.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("inn")]
        public string Inn { get; set; }

        /// <summary>
        /// Gets or sets the OKED.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("oked")]
        public string Oked { get; set; }

        /// <summary>
        /// Gets or sets the PINFL.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("pinfl")]
        public string Pinfl { get; set; }

        /// <summary>
        /// Gets or sets the VAT payer registration code.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowOrderAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowOrder]
        [Parameter("vatPayerRegCode")]
        public string VatPayerRegCode { get; set; }

        #endregion Properties
    }
}