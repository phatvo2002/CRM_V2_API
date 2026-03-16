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
                if (request?.model == null || request.model.Id == Guid.Empty)
                    return new Response<bool>("Dữ liệu không hợp lệ");

                var role = await _unitOfWork.RoleRepository.GetAsync(filter: x => x.Id == request.model.Id, cancellationToken: cancellationToken);

                if (role == null)
                {
                    return new Response<bool>("Không tìm thấy chức vụ");
                }

                try
                {   
                    if (request.model.Name != null)
                        role.Name = request.model.Name;

                    if (request.model.MoTa != null)
                        role.MoTa = request.model.MoTa;

                    if (request.model.NormalizedName != null)
                        role.NormalizedName = request.model.NormalizedName;

                    if (request.model.ConcurrencyStamp != null)
                        role.ConcurrencyStamp = request.model.ConcurrencyStamp;

                    _unitOfWork.RoleRepository.Update(entityToUpdate: role, updateAction: null);

                    var result = await _unitOfWork.SaveAsync(cancellationToken);
                    if (result > 0)
                        return new Response<bool>(true, "Cập nhật chức vụ thành công");

                    return new Response<bool>("Cập nhật chức vụ thất bại");
                }
                catch (Exception ex)
                {
                    return new Response<bool>($"Đã có lỗi xảy ra : {ex.Message}");
                }
            }
        }
    }
}
