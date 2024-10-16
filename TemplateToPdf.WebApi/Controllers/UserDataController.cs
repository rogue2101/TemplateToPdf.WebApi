using Hangfire;
using Microsoft.AspNetCore.Mvc;
using TemplateToPdf.WebApi.Services.Implementations;
using TemplateToPdf.WebApi.Services.Interfaces;
using TemplateToPdf.WebApi.Services.Models;

namespace TemplateToPdf.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private readonly IUserDataService _userDataService;

        public UserDataController(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }

        [HttpPost]
        public async Task<IActionResult> PostData(RequestModel requestModel)
        {
            if(requestModel == null)
            {
                return NoContent();
            }
            await _userDataService.PostDataAsync(requestModel);
            return Ok();
        }

        [HttpPost("hangfire")]
        public async Task<IActionResult> CreatJob()
        {
            //For sending email to the user email address
            RecurringJob.AddOrUpdate<EmailService>("EmailServiceBackgroundJob", x => x.EmailBackgroundJob(), "*/5 * * * 1-5");
            return NoContent();
        }
    }
}
