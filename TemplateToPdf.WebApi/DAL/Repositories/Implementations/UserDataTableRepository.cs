using TemplateToPdf.WebApi.DAL.DatabaseContext;
using TemplateToPdf.WebApi.DAL.Entities;
using TemplateToPdf.WebApi.DAL.Repositories.Interfaces;

namespace TemplateToPdf.WebApi.DAL.Repositories.Implementations
{
    public class UserDataTableRepository : IUserDataTableRepository
    {
        private readonly DocumentStorageDbContext _storageContext;

        public UserDataTableRepository(DocumentStorageDbContext documentStorageDbContext)
        {
            _storageContext = documentStorageDbContext;
        }
        public async Task<UserDataTable> WriteUserDataAsync(UserDataTable userData)
        {
            if (userData == null)
            {
                return null!;
            }
            await _storageContext.UserDataTable.AddAsync(userData);
            _storageContext.SaveChanges();
            return userData;
        }
    }
}
