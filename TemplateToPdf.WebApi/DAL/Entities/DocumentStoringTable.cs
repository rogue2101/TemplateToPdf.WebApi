using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TemplateToPdf.WebApi.DAL.Entities;

public partial class DocumentStoringTable
{
    public string? ObjectCode { get; set; }

    public string? ReferenceType { get; set; }
    [Key]
    public string ReferenceNumber { get; set; } = null!;

    public byte[]? Content { get; set; }

    public string? FileName { get; set; }

    public string? FileExtension { get; set; }

    public string? LanguageCode { get; set; }

    public string? CreatedUser { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public bool IsDeleted { get; set; }
}
