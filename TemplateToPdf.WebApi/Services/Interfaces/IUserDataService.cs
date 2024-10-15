using Microsoft.AspNetCore.Mvc;
using TemplateToPdf.WebApi.DAL.Entities;
using TemplateToPdf.WebApi.Services.Models;

namespace TemplateToPdf.WebApi.Services.Interfaces
{
    public interface IUserDataService
    {
        public Task<IActionResult> PostDataAsync(RequestModel requestModel);
    }
}
