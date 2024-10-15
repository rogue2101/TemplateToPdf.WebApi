using Microsoft.EntityFrameworkCore;
using TemplateToPdf.WebApi.DAL.DatabaseContext;
using TemplateToPdf.WebApi.DAL.Entities;
using TemplateToPdf.WebApi.DAL.Repositories.Interfaces;

namespace TemplateToPdf.WebApi.DAL.Repositories.Implementations
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly DocumentStorageDbContext _storageContext;

        public UserDataRepository(DocumentStorageDbContext documentStorageDbContext)
        {
            _storageContext = documentStorageDbContext;
        }
        public async Task<UserData> AddAsync(UserData userData)
        {
            if (userData == null)
            {
                throw new ArgumentNullException(nameof(userData));
            }
            await _storageContext.UserData.AddAsync(userData);
            _storageContext.SaveChanges();
            return userData;
        }

        public async Task<UserData> GetByPolicyIdAsync(string policyId)
        {
            return await _storageContext.UserData.FirstOrDefaultAsync(x => x.PolicyNumber == policyId) ?? new(); 
        }
    }
}
