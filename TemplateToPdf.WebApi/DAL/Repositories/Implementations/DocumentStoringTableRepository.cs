using TemplateToPdf.WebApi.DAL.DatabaseContext;
using TemplateToPdf.WebApi.DAL.Entities;
using TemplateToPdf.WebApi.DAL.Repositories.Interfaces;

namespace TemplateToPdf.WebApi.DAL.Repositories.Implementations
{
    public class DocumentStoringTableRepository : IDocumentStoringTableRepository
    {
        private readonly DocumentStorageDbContext _dbContext;
        public DocumentStoringTableRepository(DocumentStorageDbContext documentStorageDbContext)
        {
            _dbContext = documentStorageDbContext;
        }
        public async Task<DocumentStoringTable> SaveDocumentAsync(DocumentStoringTable document)
        {
            if(document == null)
            {
                return null!;
            }
            await _dbContext.DocumentStroringTable.AddAsync(document);
            _dbContext.SaveChanges();
            return document;
        }
    }
}
