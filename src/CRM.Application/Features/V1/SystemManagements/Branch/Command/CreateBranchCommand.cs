
using AutoMapper;
using CRM.Application.Common.Abstractions.Data;
using CRM.Application.Features.V1.SystemManagements.Branch.Modal;
using CRM.Application.Features.V1.SystemManagements.Role.Modal;
using CRM.Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
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
            private readonly ILogger<CreateBranchCommandHandle>  _logger;

            public CreateBranchCommandHandle (IUnitOfWork unitOfWork, IMapper mapper , ILogger<CreateBranchCommandHandle> logger)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _logger = logger;   
            }
            public async Task<Response<bool>> Handle(CreateBranchCommand request , CancellationToken cancellationToken)
            {
                var branchEntity = _mapper.Map<ChiNhanh>(request.RoleRequest);
                _unitOfWork.BranchRepository.Insert(branchEntity);

                var result = await _unitOfWork.SaveAsync(cancellationToken);
                if (result > 0)
                {
                    _logger.LogInformation("Tạo chi nhánh thành công với id: {BranchId}", branchEntity.Id);
                    return new Response<bool>(true, "Tạo thành công");
                }
                else
                {
                    _logger.LogError("Tạo chi nhánh thất bại với id: {BranchId}", branchEntity.Id);
                    return new Response<bool>("Đã có lỗi xảy ra");
                }
            }
        }
    }
}
