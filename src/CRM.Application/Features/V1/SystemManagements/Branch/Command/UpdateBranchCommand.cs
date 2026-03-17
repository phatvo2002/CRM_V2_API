using AutoMapper;
using CRM.Application.Common.Abstractions.Data;
using CRM.Application.Features.V1.SystemManagements.Branch.Modal;
using CRM.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Features.V1.SystemManagements.Branch.Command
{
    public class UpdateBranchCommand : IRequest<Response<bool>>
    {
        public Guid id { get; set; }
        public BranchRequest? BranchRequest { get; set; }   
        public class UpdateBranchCommandHandle : IRequestHandler<UpdateBranchCommand, Response<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly ILogger<UpdateBranchCommandHandle> _logger;
            public UpdateBranchCommandHandle(IUnitOfWork unitOfWork , IMapper mapper , ILogger<UpdateBranchCommandHandle> logger)
            {
                _unitOfWork = unitOfWork;   
                _mapper = mapper;
                _logger = logger;   
            }
            public async Task<Response<bool>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
            {
                var branchData = await _unitOfWork.BranchRepository.GetAsync(x => x.Id == request.id);
                if(branchData == null)
                {
                    return new Response<bool> { Succeed = false, Data = false, Message = "Không tìm thấy dữ liệu cần cập nhật" }; 
                }
               
                    try
                    {
                            if (request.BranchRequest != null)
                            { 
                                branchData.DiaChi = request.BranchRequest.DiaChi;
                                branchData.TenChiNhanh = request.BranchRequest.TenChiNhanh;
                                branchData.IsChiNhanhTong = request.BranchRequest.IsChiNhanhTong;
                                branchData.SoThuTu = request.BranchRequest.SoThuTu;
                                branchData.MoTa = request.BranchRequest.MoTa;
                             }
                        
                    _unitOfWork.BranchRepository.Update(branchData);
                        var result = await _unitOfWork.SaveAsync();
                        if (result > 0)
                        {
                        _logger.LogInformation($"Cập nhật chi nhánh có id {request.id} thành công");
                        return new Response<bool> { Succeed = true, Data = true, Message = "Dữ liệu đã được cập nhật thành công" };
                           
                        }else
                        {
                            _logger.LogError($"Cập nhật chi nhánh có id {request.id} thất bại");
                        return new Response<bool> { Succeed = false, Data = false, Message = "Đã có lỗi xảy ra trong hệ thống" };
                        }    
                    }
                    catch (Exception ex)
                    {
                            _logger.LogError(ex, $"Cập nhật chi nhánh có id {request.id} thất bại với lỗi: {ex.Message}");
                               return new Response<bool> { Succeed = false, Data = false, Message = $"Lỗi : {ex.Message}" };
                    }

            }
        }
    } 
}
