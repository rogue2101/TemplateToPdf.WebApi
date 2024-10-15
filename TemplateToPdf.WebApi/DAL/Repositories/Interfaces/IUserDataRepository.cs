using TemplateToPdf.WebApi.DAL.Entities;

namespace TemplateToPdf.WebApi.DAL.Repositories.Interfaces
{
    public interface IUserDataRepository
    {
        public Task<UserData> AddAsync(UserData userData);
        public Task<UserData> GetByPolicyIdAsync(string policyId);
    }
}
