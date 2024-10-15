using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TemplateToPdf.WebApi.DAL.Entities;

namespace TemplateToPdf.WebApi.DAL.DatabaseContext;

public partial class DocumentStorageDbContext : DbContext
{
    public DocumentStorageDbContext()
    {
    }

    public DocumentStorageDbContext(DbContextOptions<DocumentStorageDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Template> Content { get; set; }

    public virtual DbSet<Document> Document { get; set; }

    public virtual DbSet<UserData> UserData { get; set; }

    public virtual DbSet<Messaging> Messaging { get; set; }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
