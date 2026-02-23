using AutoMapper;
using CRM.Application.Features.V1.SystemManagements.Role.Modal;
using Microsoft.AspNetCore.Identity;

namespace CRM.Application.Features.V1.SystemManagements.Role.Mapper
{
    public class Role_MapperProfile : Profile
    {
        public Role_MapperProfile()
        {
            CreateMap<RoleRequest, IdentityRole<Guid>>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                    .ForMember(dest => dest.ConcurrencyStamp , opt => opt.MapFrom(src => Guid.NewGuid())).ReverseMap();
            CreateMap<RoleResponse , IdentityRole<Guid>>().ReverseMap();
        }
    }
}
