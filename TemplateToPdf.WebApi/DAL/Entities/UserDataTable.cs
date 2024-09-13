using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TemplateToPdf.WebApi.DAL.Entities;

public partial class UserDataTable
{
    public string? Name { get; set; }
    [Key]
    public string PolicyNumber { get; set; } = null!;

    public int? Age { get; set; }

    public decimal? Salary { get; set; }

    public string? Occupation { get; set; }

    public DateTime? PolicyExpiryDate { get; set; }

    public string? ProductCode { get; set; }

    public string? EmailAddress { get; set; }
}
