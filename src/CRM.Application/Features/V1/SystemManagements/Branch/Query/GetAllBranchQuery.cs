using AutoMapper;
using CRM.Application.Common.Abstractions.Data;
using CRM.Application.Features.V1.SystemManagements.Branch.Modal;
using CRM.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Features.V1.SystemManagements.Branch.Query
{
    public class GetAllBranchQuery : IRequest<Response<List<BranchResponse>>>
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; }   
        public class GetAllBranchQueryHandle : IRequestHandler<GetAllBranchQuery, Response<List<BranchResponse>>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;   
            public GetAllBranchQueryHandle(IUnitOfWork unitOfWork , IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;   
            }
            public async Task<Response<List<BranchResponse>>> Handle(GetAllBranchQuery request, CancellationToken cancellationToken)
            {
                var data = await _unitOfWork.BranchRepository.PaginationAsync(page: request.PageNumber , pageSize : request.PageSize);
                if (data == null)
                {
                    return new Response<List<BranchResponse>>(null, "Không có chi nhánh nào");
                }
                else
                {
                    var result = _mapper.Map<List<BranchResponse>>(data.Data);   
                    return new Response<List<BranchResponse>>(result, "Lấy danh sách chi nhánh thành công");
                }    
             
            }

        }
    }
}
