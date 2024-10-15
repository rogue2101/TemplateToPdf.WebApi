using System.ComponentModel.DataAnnotations;

namespace TemplateToPdf.WebApi.DAL.Entities;

public partial class UserData
{
    public string Name { get; set; } = string.Empty;

    [Key]
    public string PolicyNumber { get; set; } = null!;
    public int Age { get; set; } = 0!;
    public decimal? Salary { get; set; }
    public string? Occupation { get; set; }
    public DateTime PolicyExpiryDate { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
}
