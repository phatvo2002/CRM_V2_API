using CRM.Application.Common.Abstractions.Data;
using CRM.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Features.V1.SystemManagements.Role.Command
{
    public class DeleteRoleCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public class DeleteRoleCommandHandle : IRequestHandler<DeleteRoleCommand, Response<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteRoleCommandHandle(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Response<bool>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
            {
                var role = await _unitOfWork.RoleRepository.GetAsync(filter: x => x.Id == request.Id);
                if (role == null)
                {
                    return new Response<bool>("Không tìm thấy chức vụ");
                }
                else
                {
                    _unitOfWork.RoleRepository.Delete(role);
                    var result = await _unitOfWork.SaveAsync(cancellationToken);
                    if (result > 0)
                    {
                        return new Response<bool>(true, "Xóa chức vụ thành công");
                    }
                    else
                    {
                        return new Response<bool>(false, "Xóa chức vụ thất bại");
                    }
                }
            }
        }
    }
}
