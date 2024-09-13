using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemplateToPdf.WebApi.DAL.DatabaseContext;
using TemplateToPdf.WebApi.DAL.Entities;
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
            await _userDataService.PostUserDataAsync(requestModel);
            return Ok();
        }
    }
}
