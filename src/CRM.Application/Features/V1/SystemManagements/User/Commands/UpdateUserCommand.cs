using AutoMapper;
using CRM.Application.Common.Abstractions.Data;
using CRM.Application.Features.V1.SystemManagements.User.Modals;
using CRM.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CRM.Application.Features.V1.SystemManagements.Department.Command.UpdateDepartmentCommand;

namespace CRM.Application.Features.V1.SystemManagements.User.Commands
{
    public class UpdateUserCommand : IRequest<Response<bool>>
    {
        Guid Id { get; set; }
        public UserRequest? UserRequest { get; set; }
        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly ILogger<UpdateUserCommandHandler> _logger;
            public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateUserCommandHandler> logger)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _logger = logger;
            }
            public async Task<Response<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var data = await _unitOfWork.UserRepository.GetAsync(x => x.Id == request.Id);
                if (data == null)
                {
                    return new Response<bool> { Succeed = false, Data = false, Message = "Không tìm thấy dữ liệu cần cập nhật" };
                }
                try
                {
                    if (request.UserRequest != null)
                    {
                        data.MaPhongBan = request.UserRequest.MaPhongBan;
                        data.MaChucVu = request.UserRequest.MaChucVu;
                        data.ChiNhanhId = request.UserRequest.ChiNhanhId;
                        data.MaPhongBan = request.UserRequest.MaPhongBan;
                        data.NgayBatDauLamViec = request.UserRequest.NgayBatDauLamViec;
                        data.NgayThuViec = request.UserRequest.NgayThuViec;
                        data.IsActive = request.UserRequest.IsActive;
                        data.TinhTrang = request.UserRequest.TinhTrang;
                    }

                    _unitOfWork.UserRepository.Update(data);
                    var result = await _unitOfWork.SaveAsync();
                     return result > 0
                         ? new Response<bool> { Succeed = true, Data = true, Message = "Dữ liệu đã được cập nhật thành công" }
                         : new Response<bool> { Succeed = false, Data = false, Message = "Đã có lỗi xảy ra trong hệ thống" };
                }
                catch(Exception ex)
                {
                    _logger.LogError($"Cập nhật người dùng có id  {request.Id} thất bại với lỗi: {ex.Message}");
                    return new Response<bool> { Succeed = false, Data = false, Message = Message.Error() };
                }
            }
        }
    }
}
