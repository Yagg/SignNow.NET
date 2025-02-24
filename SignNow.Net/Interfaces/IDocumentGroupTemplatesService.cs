using System.Threading;
using System.Threading.Tasks;
using SignNow.Net.Model.Responses;

namespace SignNow.Net.Interfaces
{
    /// <summary>
    /// Interface for any operations with a Document Group Templates in signNow
    /// can be used to create, rename, delete, move a document group templates etc.
    /// </summary>
    public interface IDocumentGroupTemplatesService
    {
        /// <summary>
        /// Creates a document group from template
        /// </summary>
        /// <param name="documentGroupTemplateId">ID of the Document Group</param>
        /// <param name="documentGroupTemplateName">Name of the Document Group</param>
        /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
        /// <returns></returns>
        Task<DocumentGroupInfoResponse> CreateDocumentGroupFromTemplateAsync(string documentGroupTemplateId, string documentGroupTemplateName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns back all document group templates the user owns.
        /// The call is paginated, so offset and limit query parameters are required
        /// </summary>
        /// <param name="options">Limit and offset query options</param>
        /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
        /// <returns></returns>
        Task<DocumentGroupTemplatesResponse> GetDocumentGroupTemplatesAsync(IQueryToString options, CancellationToken cancellationToken = default);
    }
}
