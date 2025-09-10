using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an company type.
    /// </summary>
    public enum CompanyType
    {
        /// <summary>
        /// Legal company type.
        /// </summary>
        [EnumMember(Value = "legal")]
        Legal,

        /// <summary>
        /// Entrepreneur company type.
        /// </summary>
        [EnumMember(Value = "entrepreneur")]
        Entrepreneur,

        /// <summary>
        /// Individual company type.
        /// </summary>
        [EnumMember(Value = "individual")]
        Individual,

        /// <summary>
        /// Individual company type for UZ.
        /// </summary>
        [EnumMember(Value = "legalUZ")]
        LegalUZ,

        /// <summary>
        /// Entrepreneur company type for UZ.
        /// </summary>
        [EnumMember(Value = "entrepreneurUZ")]
        EntrepreneurUZ,

        /// <summary>
        /// Individual company type for UZ.
        /// </summary>
        [EnumMember(Value = "individualUZ")]
        IndividualUZ,

        /// <summary>
        /// Individual company type for KZ.
        /// </summary>
        [EnumMember(Value = "legalKZ")]
        LegalKZ,

        /// <summary>
        /// Entrepreneur company type for KZ.
        /// </summary>
        [EnumMember(Value = "entrepreneurKZ")]
        EntrepreneurKZ,

        /// <summary>
        /// Individual company type for KZ.
        /// </summary>
        [EnumMember(Value = "individualKZ")]
        IndividualKZ,
    }
}