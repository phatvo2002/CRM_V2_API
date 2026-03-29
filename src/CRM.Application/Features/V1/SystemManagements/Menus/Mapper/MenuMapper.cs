using AutoMapper;
using CRM.Application.Features.V1.SystemManagements.Department.Modal;
using CRM.Application.Features.V1.SystemManagements.Menus.Modal;
using Domain.Entities;


namespace CRM.Application.Features.V1.SystemManagements.Menus.Mapper
{
    internal class MenuMapper : Profile
    {
        public MenuMapper()
        {
            CreateMap<MenuRequest, Menu>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid())).ReverseMap();
            CreateMap<MenuResponse, Menu>().ReverseMap();
        }
    }
}
