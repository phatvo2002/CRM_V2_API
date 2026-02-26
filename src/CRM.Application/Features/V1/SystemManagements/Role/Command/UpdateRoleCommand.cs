using AutoMapper;
using CRM.Application.Common.Abstractions.Data;
using CRM.Application.Features.V1.SystemManagements.Role.Modal;
using CRM.Domain.Common;
using Domain.Entities;
using MediatR;

namespace CRM.Application.Features.V1.SystemManagements.Role.Command
{
    public class UpdateRoleCommand : IRequest<Response<bool>>
    {
        public sealed class UpdateRole
        {
            public Guid Id { get; set; }
            public string? Name  { get; set; }
            public string? MoTa { get; set; }
            public string? NormalizedName  { get; set; }    
            public string? ConcurrencyStamp { get; set; }
        }
        public UpdateRole? model { get; set; }
        public class UpdateRoleCommandHandle : IRequestHandler<UpdateRoleCommand, Response<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public UpdateRoleCommandHandle(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<Response<bool>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
            {
                var role = _unitOfWork.RoleRepository.GetAsync(filter: x=> x.Id ==  request.model.Id,selector : s => new ChucVu
                { 
                        Id = s.Id,
                        Name = s.Name,
                        MoTa = s.MoTa,
                        NormalizedName = s.NormalizedName,
                        ConcurrencyStamp = s.ConcurrencyStamp
                }).Result;
                try
                {
                    if(role == null)
                    {
                        return new Response<bool>("Không tìm thấy chức vụ");
                    }
                    else
                    {
                         _unitOfWork.RoleRepository.Update(entityToUpdate :  role ,updateAction  : e=>
                        {
                            e.Name = request.model.Name;
                            e.MoTa = request.model.MoTa;
                            e.NormalizedName = request.model.NormalizedName;
                            e.ConcurrencyStamp = request.model.ConcurrencyStamp;  
                        });
                        var result = await _unitOfWork.SaveAsync(cancellationToken);   
                        if(result > 0)
                        {
                            return new Response<bool>(true,"Cập nhật chức vụ thành công");
                        }
                        else
                        {
                            return new Response<bool>("Cập nhật chức vụ thất bại");
                        }   
                    }    
                }
                catch(Exception ex)
                {
                    return new Response<bool>($"Đã có lỗi xảy ra : {ex.Message}");
                }
            }
        }
    }
}
