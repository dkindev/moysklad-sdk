using System;
using System.ComponentModel;
using Confiti.MoySklad.Remap.Client.Json;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an task.
    /// </summary>
    public class TaskEntity : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the agent.
        /// </summary>
        /// <value>The agent.</value>
        public MetaEntity Agent { get; set; }

        /// <summary>
        /// Gets or sets the assignee.
        /// </summary>
        /// <value>The assignee.</value>
        public Employee Assignee { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
        public Employee Author { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been completed.
        /// </summary>
        /// <value>The date when the entity has been completed.</value>
        public DateTime? Completed { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been created.
        /// </summary>
        /// <value>The date when the entity has been created.</value>
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the deadline date.
        /// </summary>
        /// <value>The deadline date.</value>
        public DateTime? DueToDate { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>The group.</value>
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets the implementer.
        /// </summary>
        /// <value>The implementer.</value>
        public Employee Implementer { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        [DefaultValue(EmptyObjectValueProvider.EMPTY_OBJECT_VALUE)]
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PagedEntities<TaskNote> Notes { get; set; } = new PagedEntities<TaskNote>();

        /// <summary>
        /// Gets or sets the operation.
        /// </summary>
        /// <value>The operation.</value>
        public MetaEntity Operation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the task is done.
        /// </summary>
        /// <value>The value indicating whether to the task is done.</value>
        public bool? Shared { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// </summary>
        /// <value>The date when the entity has been updated.</value>
        public DateTime? Updated { get; set; }

        #endregion Properties
    }
}