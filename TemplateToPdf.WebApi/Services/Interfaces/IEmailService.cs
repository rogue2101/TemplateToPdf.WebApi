namespace TemplateToPdf.WebApi.Services.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string recipientEmail, byte[] fileContent, string fileName);
    }
}
