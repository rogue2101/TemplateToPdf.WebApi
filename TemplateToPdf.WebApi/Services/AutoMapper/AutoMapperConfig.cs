using AutoMapper;
using TemplateToPdf.WebApi.DAL.Entities;
using TemplateToPdf.WebApi.Services.Models;

namespace TemplateToPdf.WebApi.Services.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RequestModel, UserData>().ReverseMap();
            CreateMap<Template, ContentModel>().ReverseMap();
            CreateMap<DocumentModel, Document>().ReverseMap();
        }
    }
}
