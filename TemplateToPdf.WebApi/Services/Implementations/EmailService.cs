using System.Net.Mail;
using System.Net;
using TemplateToPdf.WebApi.Services.Interfaces;
using System.Net.Http;

namespace TemplateToPdf.WebApi.Services.Implementations
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string recipientEmail, byte[] fileContent, string fileName)
        {
            SmtpClient SmtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("hello.learnnearn@gmail.com", "Your password here."),
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress("hello.learnnearn@gmail.com"),
                Subject = "Regarding your policy generation.",
                Body = "Hey user, please find the attatched policy document for the registered policy.",
                IsBodyHtml = true,
            };

            mailMessage.To.Add(recipientEmail);


            using (var memoryStream = new MemoryStream(fileContent))
            {
                var attachment = new Attachment(memoryStream, fileName, "application/pdf");
                mailMessage.Attachments.Add(attachment);
                await SmtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
