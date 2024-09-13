using Microsoft.EntityFrameworkCore;
using TemplateToPdf.WebApi.DAL.DatabaseContext;
using TemplateToPdf.WebApi.DAL.Repositories.Implementations;
using TemplateToPdf.WebApi.DAL.Repositories.Interfaces;
using TemplateToPdf.WebApi.Services.AutoMapper;
using TemplateToPdf.WebApi.Services.Implementations;
using TemplateToPdf.WebApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DocumentStorageDbContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IContentTableRepository, ContentTableRepository>();
builder.Services.AddTransient<IUserDataTableRepository, UserDataTableRepository>();
builder.Services.AddTransient<IDocumentStoringTableRepository, DocumentStoringTableRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddTransient<IUserDataService, UserDataService>();
builder.Services.AddTransient<IEPolicyKitDocumentGenerationService, EPolicyKitDocumentGenerationService>();
builder.Services.AddTransient<IEmailService, EmailService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
