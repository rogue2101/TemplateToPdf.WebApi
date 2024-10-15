using TemplateToPdf.WebApi.DAL.Entities;

namespace TemplateToPdf.WebApi.DAL.Repositories.Interfaces
{
    public interface ITemplateRepository
    {
        public Task<Template> GetTemplateByTemplateCodeAsync(string templateCode);
    }
}
