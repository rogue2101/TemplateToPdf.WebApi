using Microsoft.EntityFrameworkCore;
using TemplateToPdf.WebApi.DAL.DatabaseContext;
using TemplateToPdf.WebApi.DAL.Entities;
using TemplateToPdf.WebApi.DAL.Repositories.Interfaces;

namespace TemplateToPdf.WebApi.DAL.Repositories.Implementations
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DocumentStorageDbContext _dbContext;
        public DocumentRepository(DocumentStorageDbContext documentStorageDbContext)
        {
            _dbContext = documentStorageDbContext;
        }
        public async Task<Document> AddAsync(Document document)
        {
            if(document == null)
            {
                throw new ArgumentNullException("No Doument Received");
            }
            await _dbContext.Document.AddAsync(document);
            _dbContext.SaveChanges();
            return document;
        }

        public async Task<Document> GetByRefereceNumberAsync(string referenceNumber)
        {
            return await _dbContext.Document.FirstOrDefaultAsync(x => x.ReferenceNumber == referenceNumber) ?? new ();
        }
    }
}
