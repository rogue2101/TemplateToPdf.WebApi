using TemplateToPdf.WebApi.DAL.Entities;

namespace TemplateToPdf.WebApi.DAL.Repositories.Interfaces
{
    public interface IMessagingRepository
    {
        Task<List<Messaging>> GetAllAsync();
        Task AddAsync(Messaging entity);
        Task UpdateAsync(Messaging entity);
        Task UpdateAllAsync(List<Messaging> messagings);
    }
}
