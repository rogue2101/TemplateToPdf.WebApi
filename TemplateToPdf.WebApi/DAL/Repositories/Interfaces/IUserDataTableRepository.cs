using TemplateToPdf.WebApi.DAL.Entities;

namespace TemplateToPdf.WebApi.DAL.Repositories.Interfaces
{
    public interface IUserDataTableRepository
    {
        public Task<UserDataTable> WriteUserDataAsync(UserDataTable userData);
    }
}
