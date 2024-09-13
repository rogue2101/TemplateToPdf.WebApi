using TemplateToPdf.WebApi.DAL.Entities;

namespace TemplateToPdf.WebApi.DAL.Repositories.Interfaces
{
    public interface IDocumentStoringTableRepository
    {
        public Task<DocumentStoringTable> SaveDocumentAsync(DocumentStoringTable document);
    }
}
