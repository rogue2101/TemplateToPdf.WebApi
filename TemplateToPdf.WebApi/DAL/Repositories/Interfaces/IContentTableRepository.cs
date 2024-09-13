using TemplateToPdf.WebApi.DAL.Entities;

namespace TemplateToPdf.WebApi.DAL.Repositories.Interfaces
{
    public interface IContentTableRepository
    {
        public Task<ContentTable> GetContentByDocumentCodeAsync(string docCode);
    }
}
