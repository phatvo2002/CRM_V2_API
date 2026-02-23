using AutoMapper;
using CRM.Application.Common.Abstractions.Data;
using CRM.Application.Features.V1.SystemManagements.Role.Modal;
using CRM.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CRM.Application.Features.V1.SystemManagements.Role.Command
{
    public class CreateRoleCommand : IRequest<Response<bool>>
    {
        public RoleRequest? RoleRequest { get; set; }

        public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Response<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public CreateRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<Response<bool>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
            {
                var roleEntity = _mapper.Map<IdentityRole<Guid>>(request.RoleRequest);
                _unitOfWork.RoleRepository.Insert(roleEntity);

                var result = await _unitOfWork.SaveAsync(cancellationToken) ;
                if(result > 0)
                {
                    return new Response<bool>(true, "Tạo thành công");
                }
                else
                {
                    return new Response<bool>("Đã có lỗi xảy ra");
                }

            }
        }
    }
}
