using CRM.Application.Common.Abstractions.Data;
using CRM.Application.Features.V1.SystemManagements.Branch.Command;
using CRM.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CRM.Application.Features.V1.SystemManagements.Department.Command
{
    public class DeleteDepartmentCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public class DeleteDepartmentCommandHandle : IRequestHandler<DeleteDepartmentCommand, Response<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILogger<DeleteBranchCommand> _logger;
            public DeleteDepartmentCommandHandle(IUnitOfWork unitOfWork, ILogger<DeleteBranchCommand> logger)
            {
                _unitOfWork = unitOfWork;
                _logger = logger;
            }
            public async Task<Response<bool>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
            {
                var checkData = await _unitOfWork.BranchRepository.GetAsync(x => x.Id == request.Id);
                if (checkData == null)
                {
                    _logger.LogWarning($"Không tìm thấy phòng ban có id {request.Id} để xóa");
                    return new Response<bool>("Không tìm thấy dữ liệu cần xóa");
                }
                try
                {
                    _unitOfWork.BranchRepository.Delete(checkData);
                    var result = await _unitOfWork.SaveAsync(cancellationToken);
                    if (result > 0)
                    {
                        _logger.LogInformation($"Xóa phòng ban có id {request.Id} thành công");
                        return new Response<bool>(true, "Xóa phòng ban thành công");
                    }
                    else
                    {
                        _logger.LogError($"Xóa phòng ban có id {request.Id} thất bại");
                        return new Response<bool>("Đã có lỗi xảy ra trong hệ thống");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex,Message.Error());
                    return new Response<bool>("Đã có lỗi xảy ra trong hệ thống");
                }
            }
        }
    }
}
