using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents an query for <see cref="Counterparty"/>.
    /// See also: https://dev.moysklad.ru/doc/api/remap/1.2/dictionaries/#suschnosti-kontragent-kontragenty.
    /// </summary>
    public class CounterpartyQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the accounts.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("accounts")]
        public PagedEntities<AgentAccount> Accounts { get; set; }

        /// <summary>
        /// Gets or sets the contact persons.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("contactpersons")]
        public PagedEntities<ContactPerson> ContactPersons { get; set; }

        /// <summary>
        /// Gets or sets the files.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("files")]
        public PagedEntities<File> Files { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [Filter(allowNull: false)]
        [AllowExpand]
        [Parameter("group")]
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [AllowExpand]
        [Parameter("notes")]
        public PagedEntities<CounterpartyNote> Notes { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowExpand]
        [Parameter("owner")]
        public Employee Owner { get; set; }

        /// <summary>
        /// Gets or sets the price type.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowExpand]
        [Parameter("priceType")]
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// <see cref="FilterAttribute"/>;
        /// <see cref="AllowExpandAttribute"/>
        /// allowed.
        /// </summary>
        [Filter]
        [AllowExpand]
        [Parameter("state")]
        public State State { get; set; }

        #endregion Properties
    }
}