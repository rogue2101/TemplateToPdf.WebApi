using Microsoft.EntityFrameworkCore;
using TemplateToPdf.WebApi.DAL.DatabaseContext;
using TemplateToPdf.WebApi.DAL.Entities;
using TemplateToPdf.WebApi.DAL.Repositories.Interfaces;

namespace TemplateToPdf.WebApi.DAL.Repositories.Implementations
{
    public class ContentTableRepository : IContentTableRepository
    {
        private readonly DocumentStorageDbContext _storageContext;
        public ContentTableRepository(DocumentStorageDbContext documentStorageDbContext)
        {
            _storageContext = documentStorageDbContext;
        }
        public async Task<ContentTable> GetContentByDocumentCodeAsync(string docCode)
        {
            var content = await _storageContext.ContentTable.FirstOrDefaultAsync(p => p.DocumentCode == docCode);

            if(content == null)
            {
                return null!;
            }
            return content;
        }
    }
}
