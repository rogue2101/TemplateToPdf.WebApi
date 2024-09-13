using AutoMapper;
using TemplateToPdf.WebApi.DAL.Entities;
using TemplateToPdf.WebApi.Services.Models;

namespace TemplateToPdf.WebApi.Services.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RequestModel, UserDataTable>().ReverseMap();
            CreateMap<ContentTable, ContentModel>().ReverseMap();
            CreateMap<DocumentModel, DocumentStoringTable>().ReverseMap();
        }
    }
}
