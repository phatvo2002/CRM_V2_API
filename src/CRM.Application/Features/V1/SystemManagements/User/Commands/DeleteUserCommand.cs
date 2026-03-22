using CRM.Application.Common.Abstractions.Data;
using CRM.Application.Features.V1.SystemManagements.Branch.Command;
using CRM.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Features.V1.SystemManagements.User.Commands
{
    public class DeleteUserCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILogger<DeleteBranchCommand> _logger;
            public DeleteUserCommandHandler(IUnitOfWork unitOfWork , ILogger<DeleteBranchCommand> logger)
            {
                _logger = logger;
                _unitOfWork = unitOfWork;
            }
            public async Task<Response<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var checkData = await _unitOfWork.UserRepository.GetAsync(x => x.Id == request.Id);
                if (checkData == null)
                {
                    _logger.LogWarning($"Không tìm thấy người dùng có id {request.Id} để xóa");
                    return new Response<bool>("Không tìm thấy dữ liệu cần xóa");
                }
                try
                {
                    _unitOfWork.UserRepository.Delete(checkData);
                    var result = await _unitOfWork.SaveAsync(cancellationToken);
                    if (result > 0)
                    {
                        _logger.LogInformation($"Xóa người dùng có id {request.Id} thành công");
                        return new Response<bool>(true, "Xóa người dùng thành công");
                    }
                    else
                    {
                        _logger.LogError($"Xóa người dùng có id {request.Id} thất bại");
                        return new Response<bool>("Đã có lỗi xảy ra trong hệ thống");
                    }
                }
                catch (Exception ex) {
                    _logger.LogError(ex, $"Đã có lỗi xảy ra khi xóa người dùng có id {request.Id}");
                    return new Response<bool>("Đã có lỗi xảy ra trong hệ thống");
                }
                throw new NotImplementedException();
            }
        }
    }
}
