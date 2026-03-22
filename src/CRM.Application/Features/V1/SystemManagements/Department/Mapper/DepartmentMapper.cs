using AutoMapper;
using CRM.Application.Features.V1.SystemManagements.Department.Modal;
using Domain.Entities;


namespace CRM.Application.Features.V1.SystemManagements.Department.Mapper
{
    public class DepartmentMapper : Profile
    {
        public DepartmentMapper() {
            CreateMap<DepartmentRequest, PhongBan>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid())).ReverseMap();
            CreateMap<DepartmentResponse, PhongBan>().ReverseMap();
        }
    }
}
