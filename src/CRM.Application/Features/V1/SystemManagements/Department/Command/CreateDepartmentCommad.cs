using AutoMapper;
using CRM.Application.Common.Abstractions.Data;
using CRM.Application.Features.V1.SystemManagements.Department.Modal;
using CRM.Application.Features.V1.SystemManagements.Role.Command;
using CRM.Application.Features.V1.SystemManagements.Role.Modal;
using CRM.Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Features.V1.SystemManagements.Department.Command
{
    public class CreateDepartmentCommad : IRequest<Response<bool>>
    {
        public DepartmentRequest? DepartmendRequest { get; set; }

        public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommad, Response<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public CreateDepartmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<Response<bool>> Handle(CreateDepartmentCommad request, CancellationToken cancellationToken)
            {
                var departmentEntity = _mapper.Map<PhongBan>(request.DepartmendRequest);
                _unitOfWork.DepartmentRepository.Insert(departmentEntity);

                var result = await _unitOfWork.SaveAsync(cancellationToken);
                if (result > 0)
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
