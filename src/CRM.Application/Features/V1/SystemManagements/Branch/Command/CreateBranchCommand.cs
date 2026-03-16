
using AutoMapper;
using CRM.Application.Common.Abstractions.Data;
using CRM.Application.Features.V1.SystemManagements.Branch.Modal;
using CRM.Application.Features.V1.SystemManagements.Role.Modal;
using CRM.Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Features.V1.SystemManagements.Branch.Command
{
    public class CreateBranchCommand : IRequest<Response<bool>> 
    {
        public BranchRequest? RoleRequest { get; set; }

        public class CreateBranchCommandHandle : IRequestHandler<CreateBranchCommand, Response<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateBranchCommandHandle (IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<Response<bool>> Handle(CreateBranchCommand request , CancellationToken cancellationToken)
            {
                var branchEntity = _mapper.Map<ChiNhanh>(request.RoleRequest);
                _unitOfWork.BranchRepository.Insert(branchEntity);

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
