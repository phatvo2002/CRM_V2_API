using AutoMapper;
using CRM.Application.Features.V1.SystemManagements.Branch.Modal;
using CRM.Application.Features.V1.SystemManagements.Role.Modal;
using Domain.Entities;


namespace CRM.Application.Features.V1.SystemManagements.Branch.Mapper
{
    public class Branch_MapperProfile : Profile
    {
        public Branch_MapperProfile() {
            CreateMap<BranchRequest, ChiNhanh>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid())).ReverseMap();
                   CreateMap<RoleResponse, ChiNhanh>().ReverseMap();
        }
    }
}
