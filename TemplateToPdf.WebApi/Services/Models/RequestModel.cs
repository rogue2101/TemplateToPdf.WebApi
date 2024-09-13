namespace TemplateToPdf.WebApi.Services.Models
{
    public class RequestModel
    {
        public string? Name { get; set; }

        public string PolicyNumber { get; set; } = null!;

        public int? Age { get; set; }

        public decimal? Salary { get; set; }

        public string? Occupation { get; set; }

        public DateTime? PolicyExpiryDate { get; set; }

        public string? ProductCode { get; set; }

        public string? EmailAddress { get; set; }
    }
}
