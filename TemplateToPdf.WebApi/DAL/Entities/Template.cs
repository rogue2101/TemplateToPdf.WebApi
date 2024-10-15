using System.ComponentModel.DataAnnotations;

namespace TemplateToPdf.WebApi.DAL.Entities;

public partial class Template
{
    [Key]
    public int Id { get; set; }

    public string DocumentCode { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public string ContentType { get; set; } = null!;

    public string? Content { get; set; }

    public byte[]? ContentBinary { get; set; }

    public bool IsDeleted { get; set; }

    public string CreatedUser { get; set; } = null!;

    public DateTime? CreatedDateTime { get; set; }

    public string? ModifiedUser { get; set; }

    public DateTime? ModifiedDateTime { get; set; }
}
