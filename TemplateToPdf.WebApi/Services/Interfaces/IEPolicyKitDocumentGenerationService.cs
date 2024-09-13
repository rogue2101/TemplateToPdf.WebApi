using TemplateToPdf.WebApi.DAL.Entities;
using TemplateToPdf.WebApi.Services.Models;

namespace TemplateToPdf.WebApi.Services.Interfaces
{
    public interface IEPolicyKitDocumentGenerationService
    {
        public Task<DocumentModel> GenrateDocumentAsync(UserDataTable userData);
    }
}
