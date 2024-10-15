using System.ComponentModel.DataAnnotations;

namespace TemplateToPdf.WebApi.DAL.Entities
{
    public class Messaging
    {
        [Key]
        public string? PolicyNumber {  get; set; }
        public string? Destination {  get; set; }
        public string? DestinationCc {  get; set; }
        public string? DestinationBcc { get; set; }
        public string? Body {  get; set; }
        public int Attempt {  get; set; }
        public int MaxAttempt {  get; set; }
        public DateTime LastAttempt { get; set; }  = DateTime.UtcNow;
        public bool IsSent { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}