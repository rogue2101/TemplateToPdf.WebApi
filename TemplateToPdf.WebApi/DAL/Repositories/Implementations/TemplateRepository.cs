using Microsoft.EntityFrameworkCore;
using TemplateToPdf.WebApi.DAL.DatabaseContext;
using TemplateToPdf.WebApi.DAL.Entities;
using TemplateToPdf.WebApi.DAL.Repositories.Interfaces;

namespace TemplateToPdf.WebApi.DAL.Repositories.Implementations
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly DocumentStorageDbContext _storageContext;
        public TemplateRepository(DocumentStorageDbContext documentStorageDbContext)
        {
            _storageContext = documentStorageDbContext;
        }
        public async Task<Template> GetTemplateByTemplateCodeAsync(string docCode)
        {
            var content = await _storageContext.Content.FirstOrDefaultAsync(p => p.DocumentCode == docCode);

            if(content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }
            return content;
        }
    }
}
