using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using TemplateToPdf.WebApi.DAL.Entities;
using TemplateToPdf.WebApi.DAL.Repositories.Implementations;
using TemplateToPdf.WebApi.DAL.Repositories.Interfaces;
using TemplateToPdf.WebApi.Services.Interfaces;
using TemplateToPdf.WebApi.Services.Models;

namespace TemplateToPdf.WebApi.Services.Implementations
{
    public class UserDataService : IUserDataService
    {
        private readonly IUserDataTableRepository _userDataTableRepository;
        private readonly IEPolicyKitDocumentGenerationService _policyKitDocumentGenerationService;
        private readonly IDocumentStoringTableRepository _documentStoringTableRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        public UserDataService(IUserDataTableRepository userDataTableRepository, IMapper mapper, IEPolicyKitDocumentGenerationService policyKitDocumentGenerationService, IDocumentStoringTableRepository documentStoringTable, IEmailService emailService)
        {
            _userDataTableRepository = userDataTableRepository;
            _mapper = mapper;
            _policyKitDocumentGenerationService = policyKitDocumentGenerationService;
            _documentStoringTableRepository = documentStoringTable;
            _emailService = emailService;
        }
        public async Task<IActionResult> PostUserDataAsync(RequestModel requestModel)
        {
            //For creating the user data and storing for further uses
            UserDataTable userData = await _userDataTableRepository.WriteUserDataAsync(_mapper.Map<UserDataTable>(requestModel));
            
            //For generating the pdf for user data and storing for further uses
            DocumentStoringTable generatedDoc =  await _documentStoringTableRepository.SaveDocumentAsync(_mapper.Map<DocumentStoringTable>(await _policyKitDocumentGenerationService.GenrateDocumentAsync(userData)));

            //For sending email to the user email address
            await _emailService.SendEmailAsync(userData.EmailAddress!, generatedDoc.Content!, generatedDoc.FileName!);
            
            ////For saving the stored data in pdf form in the local desktop
            //string customPath = @"C:\Users\remotestate\Documents\CreatedDocuments";

            //if (!Directory.Exists(customPath))
            //{
            //    Directory.CreateDirectory(customPath);
            //}

            //string filePath = Path.Combine(customPath, "document.pdf");

            //await System.IO.File.WriteAllBytesAsync(filePath, generatedDoc.Content!);

            //Returning ok result after the user data has been saved and generated succesfully
            return new OkObjectResult(new { message = "User data saved successfully", data = userData });
        }
    }
}
