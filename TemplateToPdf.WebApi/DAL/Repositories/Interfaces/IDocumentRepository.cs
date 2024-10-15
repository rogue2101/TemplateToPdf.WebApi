using TemplateToPdf.WebApi.DAL.Entities;

namespace TemplateToPdf.WebApi.DAL.Repositories.Interfaces
{
    public interface IDocumentRepository
    {
        public Task<Document> AddAsync(Document document);
        public Task<Document> GetByRefereceNumberAsync(string referenceNumber);
    }
}
