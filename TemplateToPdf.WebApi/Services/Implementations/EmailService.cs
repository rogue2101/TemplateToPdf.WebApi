using System.Net.Mail;
using System.Net;
using TemplateToPdf.WebApi.Services.Interfaces;
using TemplateToPdf.WebApi.DAL.Repositories.Interfaces;
using TemplateToPdf.WebApi.DAL.Entities;
using Hangfire;

namespace TemplateToPdf.WebApi.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly IMessagingRepository _messagingRepository;
        private readonly IDocumentRepository _documentRepository;
        public EmailService(IConfiguration configuration, IMessagingRepository messagingRepository, IUserDataRepository userDataRepository, IDocumentRepository documentRepository)
        {
            _configuration = configuration;
            _messagingRepository = messagingRepository;
            _documentRepository = documentRepository;
        }

        [DisableConcurrentExecution(60)]
        [AutomaticRetry(Attempts = 5)]
        public async Task EmailBackgroundJob()
        {
            List<Messaging> messagingEntities = await _messagingRepository.GetAllAsync();
            foreach (var entity in messagingEntities)
            {
                try
                {
                    Document document = await _documentRepository.GetByRefereceNumberAsync(entity.PolicyNumber);
                    await SendEmailAsync(entity, document);
                    entity.IsSent = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                entity.Attempt++;
                entity.LastAttempt = DateTime.UtcNow.AddHours(5.5);
            }
            await _messagingRepository.UpdateAllAsync(messagingEntities);
        }
        private async Task SendEmailAsync(Messaging messagingUserData, Document document)
        {
            SmtpClient SmtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = Int32.Parse(_configuration["EmailCredentials:SMTPPort"]!),
                Credentials = new NetworkCredential(_configuration["EmailCredentials:Email"], _configuration["EmailCredentials:Password"]),
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["EmailCredentials:Email"]!),
                Subject = "Regarding your policy generation.",
                Body = messagingUserData.Body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(messagingUserData.Destination);
            using (var memoryStream = new MemoryStream(document.Content))
            {
                var attachment = new Attachment(memoryStream, document.FileName, "application/pdf");
                mailMessage.Attachments.Add(attachment);
                await SmtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
