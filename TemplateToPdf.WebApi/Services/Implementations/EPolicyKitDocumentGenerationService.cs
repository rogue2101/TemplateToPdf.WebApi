using AutoMapper;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using TemplateToPdf.WebApi.DAL.Entities;
using TemplateToPdf.WebApi.DAL.Repositories.Interfaces;
using TemplateToPdf.WebApi.Services.Interfaces;
using TemplateToPdf.WebApi.Services.Models;

namespace TemplateToPdf.WebApi.Services.Implementations
{
    public class EPolicyKitDocumentGenerationService : IEPolicyKitDocumentGenerationService
    {
        private readonly ITemplateRepository _temlateRepository;
        private readonly IMapper _mapper;

        public EPolicyKitDocumentGenerationService(ITemplateRepository templateRepository, IMapper mapper)
        {
            _temlateRepository = templateRepository;
            _mapper = mapper;
        }


        public async Task<DocumentModel> GenerateDocumentAsync(UserData userData)
        {
            try
            {
                Template contentRepo = await _temlateRepository.GetTemplateByTemplateCodeAsync("userpolicy");
                ContentModel content = _mapper.Map<ContentModel>(contentRepo);

                string populatedData = PopulateDataInHtml(content.Content!, userData);

                DocumentModel document = await CreateDocumentAsync(populatedData, userData);

                return document;
            }
            catch (Exception ex)
            {
                throw new Exception(message:"No template found for the required template code.");
            }
        }

        public string PopulateDataInHtml(string html,  UserData userData)
        {
            html = html.Replace("{{Name}}", userData.Name);
            html = html.Replace("{{PolicyNumber}}",userData.PolicyNumber);
            html = html.Replace("{{Age}}",userData.Age.ToString());
            html = html.Replace("{{Salary}}", userData.Salary.ToString());
            html = html.Replace("{{Occupation}}", userData.Occupation);
            html = html.Replace("{{ProductCode}}", userData.ProductCode);
            html = html.Replace("{{PolicyExpiryDate}}", userData.PolicyExpiryDate.ToString());

            return html;
        }

        public async Task<DocumentModel> CreateDocumentAsync(string populatedData, UserData userData)
        {
            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            await page.SetContentAsync(populatedData);
            byte[] pdfData = await page.PdfDataAsync(new PdfOptions
            {
                Format = PaperFormat.A4,
                PrintBackground = true,
                MarginOptions = new MarginOptions { Top = "10px", Bottom = "10px" }
            });

            await browser.CloseAsync();

            DocumentModel documentModel = new DocumentModel
            {
                ObjectCode = $"{userData.PolicyNumber}-{userData.ProductCode}",
                ReferenceType = "Policy",
                ReferenceNumber = userData.PolicyNumber,
                Content = pdfData,
                FileName = $"{userData.PolicyNumber}" + DateTime.Now.ToString(),
                FileExtension = ".pdf",
                LanguageCode = "km-KH",
                CreatedUser = "Raj",
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
            };
            return documentModel;
        }
    }
}
