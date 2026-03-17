using CRM.Application.Common.Abstractions.Data;
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
    public class DeleteBranchCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public class DeleteBranchCommandHandle : IRequestHandler<DeleteBranchCommand, Response<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILogger<DeleteBranchCommand> _logger;
            public DeleteBranchCommandHandle(IUnitOfWork unitOfWork , ILogger<DeleteBranchCommand> logger)
            {
                _unitOfWork = unitOfWork;
                _logger = logger;
            }
            public async Task<Response<bool>> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
            {
                var checkData = await _unitOfWork.BranchRepository.GetAsync(x => x.Id == request.Id);
                if (checkData == null)
                {
                    _logger.LogWarning("Không tìm thấy chi nhánh có id {Id} để xóa", request.Id);
                    return new Response<bool>("Không tìm thấy dữ liệu cần xóa");
                }
                try
                {
                    _unitOfWork.BranchRepository.Delete(checkData);
                    var result = await _unitOfWork.SaveAsync(cancellationToken);
                    if (result > 0)
                    {
                        _logger.LogInformation("Xóa chi nhánh có id {Id} thành công", request.Id);
                        return new Response<bool>(true, "Xóa chi nhánh thành công");
                    }
                    else
                    {
                        _logger.LogError("Xóa chi nhánh có id {Id} thất bại", request.Id);
                        return new Response<bool>("Đã có lỗi xảy ra trong hệ thống");
                    }
                }
                catch (Exception ex) {
                    _logger.LogError(ex, "Đã có lỗi xảy ra khi xóa chi nhánh có id {Id}", request.Id);
                    return new Response<bool>("Đã có lỗi xảy ra trong hệ thống");
                }
                
            }
        }
    }
}
