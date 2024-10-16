using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TemplateToPdf.WebApi.DAL.Entities;
using TemplateToPdf.WebApi.DAL.Repositories.Interfaces;
using TemplateToPdf.WebApi.Services.Constants;
using TemplateToPdf.WebApi.Services.Interfaces;
using TemplateToPdf.WebApi.Services.Models;

namespace TemplateToPdf.WebApi.Services.Implementations
{
    public class UserDataService : IUserDataService
    {
        private readonly IUserDataRepository _userDataRepository;
        private readonly IEPolicyKitDocumentGenerationService _policyKitDocumentGenerationService;
        private readonly IDocumentRepository _documentRepository;
        private readonly IMessagingRepository _messagingRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        public UserDataService(IUserDataRepository userDataTableRepository, IMapper mapper, IEPolicyKitDocumentGenerationService policyKitDocumentGenerationService, IDocumentRepository documentStoringTable, IEmailService emailService, IMessagingRepository messagingRepository)
        {
            _userDataRepository = userDataTableRepository;
            _mapper = mapper;
            _policyKitDocumentGenerationService = policyKitDocumentGenerationService;
            _documentRepository = documentStoringTable;
            _emailService = emailService;
            _messagingRepository = messagingRepository;
        }
        public async Task<IActionResult> PostDataAsync(RequestModel requestModel)
        {
            //For creating the user data and storing in database
            try
            {
                //creating user
                var user = _mapper.Map<UserData>(requestModel);
                UserData userData = await _userDataRepository.AddAsync(user);

                //For generating the pdf for user data 
                var generatedDocument = await _policyKitDocumentGenerationService.GenerateDocumentAsync(userData);
                var generatedMappedDocument = _mapper.Map<Document>(generatedDocument);
                Document generatedDoc = await _documentRepository.AddAsync(generatedMappedDocument);

                //Adding data to messaging table
                Messaging messageEntity = new Messaging()
                {
                    PolicyNumber = userData.PolicyNumber,
                    Destination = userData.EmailAddress,
                    DestinationCc = null,
                    DestinationBcc = null,
                    Body = MessagingConstants.bodyConst.Replace("USER", userData.Name),
                    Attempt = 0,
                    MaxAttempt = MessagingConstants.maxAttemptConst,
                    IsSent = false,
                    IsDeleted = false,
                    CreatedDateTime = DateTime.UtcNow,
                    UpdatedDateTime = DateTime.UtcNow
                };

                await _messagingRepository.AddAsync(messageEntity);

                return new OkObjectResult(new { message = "User data saved successfully", data = userData });
            }
            catch(Exception ex)
            {
                throw new Exception(message:"User Data cannot be null.");
            }
        }
    }
}