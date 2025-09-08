using System;
using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;

namespace Confiti.MoySklad.Remap.Api
{
    /// <inheritdoc/>
    public class TaskApi : EntityApiAccessor<TaskEntity, ApiParameterBuilder, ApiParameterBuilder>
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="TaskApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public TaskApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/task", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Creates the <see cref="TaskNote"/>.
        /// </summary>
        /// <param name="taskId">The <see cref="TaskEntity"/> ID.</param>
        /// <param name="taskNote">The <see cref="TaskNote"/> to create.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the created <see cref="TaskNote"/>.</returns>
        public virtual async Task<ApiResponse<TaskNote>> CreateNoteAsync(Guid taskId, TaskNote taskNote)
        {
            if (taskNote == null)
                throw new ArgumentNullException(nameof(taskNote));

            return await CallAsync<TaskNote>(new RequestContext($"{Path}/{taskId}/notes", HttpMethod.Post).WithBody(taskNote)).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes the <see cref="TaskNote"/>.
        /// </summary>
        /// <param name="taskId">The <see cref="TaskEntity"/> ID.</param>
        /// <param name="taskNoteId">The <see cref="TaskNote"/> ID.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteNoteAsync(Guid taskId, Guid taskNoteId)
        {
            return CallAsync(new RequestContext($"{Path}/{taskId}/notes/{taskNoteId}", HttpMethod.Delete));
        }

        /// <summary>
        /// Deletes the <see cref="TaskNote"/>.
        /// </summary>
        /// <param name="taskId">The <see cref="TaskEntity"/> ID.</param>
        /// <param name="taskNote">The <see cref="TaskNote"/> to delete.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual async Task<ApiResponse> DeleteNoteAsync(Guid taskId, TaskNote taskNote)
        {
            if (taskNote == null)
                throw new ArgumentNullException(nameof(taskNote));

            var taskNoteId = taskNote.GetId();
            if (!taskNoteId.HasValue)
                throw new ApiException(400, "The entity id cannot be null.");

            return await DeleteNoteAsync(taskId, taskNoteId.Value).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the <see cref="TaskNote"/> by ID for related <see cref="TaskEntity"/> ID.
        /// </summary>
        /// <param name="taskId">The <see cref="TaskEntity"/> ID.</param>
        /// <param name="taskNoteId">The <see cref="TaskNote"/> ID.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="TaskNote"/>.</returns>
        public virtual Task<ApiResponse<TaskNote>> GetNoteAsync(Guid taskId, Guid taskNoteId)
        {
            return CallAsync<TaskNote>(new RequestContext($"{Path}/{taskId}/notes/{taskNoteId}"));
        }

        /// <summary>
        /// Gets the list of <see cref="TaskNote"/> for related <see cref="TaskEntity"/> ID and query (optional).
        /// </summary>
        /// <param name="taskId">The <see cref="TaskEntity"/> ID.</param>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the list of <see cref="TaskNote"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<TaskNote>>> GetNotesAsync(Guid taskId, ApiParameterBuilder query = null)
        {
            return CallAsync<EntitiesResponse<TaskNote>>(new RequestContext($"{Path}/{taskId}/notes").WithQuery(query));
        }

        /// <summary>
        /// Updates the <see cref="TaskNote"/>.
        /// </summary>
        /// <param name="taskId">The <see cref="TaskEntity"/> ID.</param>
        /// <param name="taskNote">The <see cref="TaskNote"/> to update.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the updated <see cref="TaskNote"/>.</returns>
        public virtual async Task<ApiResponse<TaskNote>> UpdateNoteAsync(Guid taskId, TaskNote taskNote)
        {
            if (taskNote == null)
                throw new ArgumentNullException(nameof(taskNote));

            var taskNoteId = taskNote.GetId();
            if (!taskNoteId.HasValue)
                throw new ApiException(400, "The entity id cannot be null.");

            var requestContext = new RequestContext($"{Path}/{taskId}/notes/{taskNoteId}", HttpMethod.Put)
                .WithBody(taskNote);

            return await CallAsync<TaskNote>(requestContext).ConfigureAwait(false);
        }

        #endregion Methods
    }
}