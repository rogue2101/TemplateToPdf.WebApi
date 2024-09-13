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

    public virtual DbSet<ContentTable> ContentTable { get; set; }

    public virtual DbSet<DocumentStoringTable> DocumentStroringTable { get; set; }

    public virtual DbSet<UserDataTable> UserDataTable { get; set; }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
