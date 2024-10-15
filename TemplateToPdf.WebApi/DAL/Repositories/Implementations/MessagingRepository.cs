using Microsoft.EntityFrameworkCore;
using TemplateToPdf.WebApi.DAL.DatabaseContext;
using TemplateToPdf.WebApi.DAL.Entities;
using TemplateToPdf.WebApi.DAL.Repositories.Interfaces;

namespace TemplateToPdf.WebApi.DAL.Repositories.Implementations
{
    public class MessagingRepository : IMessagingRepository
    {
        private readonly DocumentStorageDbContext _dbContext;
        public MessagingRepository(DocumentStorageDbContext documentStorageDbContext)
        {
            _dbContext = documentStorageDbContext;
        }
        public async Task AddAsync(Messaging entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("Null Entity Found");
            }
            await _dbContext.Messaging.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public async Task<List<Messaging>> GetAllAsync()
        {
           return await _dbContext.Messaging.Where(p => p.IsSent == false && p.Attempt<p.MaxAttempt && p.IsDeleted==false).ToListAsync();
        }

        public async Task UpdateAsync(Messaging entity)
        {
            if(entity == null )
            {
                throw new ArgumentNullException("Null Entiry Found");
            }
            _dbContext.Messaging.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAllAsync(List<Messaging> messagings)
        {
            foreach(Messaging entity in messagings)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
