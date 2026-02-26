using AutoMapper;
using CRM.Application.Features.V1.SystemManagements.Role.Modal;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CRM.Application.Features.V1.SystemManagements.Role.Mapper
{
    public class Role_MapperProfile : Profile
    {
        public Role_MapperProfile()
        {
            CreateMap<RoleRequest, ChucVu>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                    .ForMember(dest => dest.ConcurrencyStamp , opt => opt.MapFrom(src => Guid.NewGuid())).ReverseMap();
            CreateMap<RoleResponse , ChucVu>().ReverseMap();
        }
    }
}
