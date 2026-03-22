using AutoMapper;
using CRM.Application.Common.Abstractions.Data;
using CRM.Application.Features.V1.SystemManagements.User.Modals;
using CRM.Domain.Common;
using CRM.Domain.Common.Helper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CRM.Application.Features.V1.SystemManagements.User.Commands
{
    public class CreateUserCommand : IRequest<Response<UserResponse>>
    {
        public UserRequest? UserRequest { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<UserResponse>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;   
            private readonly ILogger<CreateUserCommandHandler> _logger;
            public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper , ILogger<CreateUserCommandHandler> logger)
            {   
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _logger = logger;   
            }
            public async Task<Response<UserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var data = await _unitOfWork.UserRepository.GetAsync(filter : x=> x.Email == request.UserRequest.Email && x.UserName == request.UserRequest.UserName ,cancellationToken : cancellationToken);
                if (data != null)
                {
                    return new Response<UserResponse>("Email hoặc tên đăng nhập đã tồn tại");
                }
                    try
                    {
                        var passwordHash = new PasswordHasher();
                        var password = passwordHash.HashPassword(request.UserRequest.PasswordHash);
                        Nguoidung nguoidung = new Nguoidung()
                        {
                            Id = Guid.NewGuid(),
                            HoVaDem = request.UserRequest.HoVaDem,
                            Ten = request.UserRequest.Ten,
                            DiaChi = request.UserRequest.DiaChi,
                            Email = request.UserRequest.Email,
                            NormalizedEmail = request.UserRequest.Email.ToUpper(),
                            NgayThuViec = request.UserRequest.NgayThuViec,
                            NgayBatDauLamViec = request.UserRequest.NgayBatDauLamViec,
                            IsActive = false,
                            IsDeleted = false,
                            PhoneNumber = request.UserRequest.PhoneNumber,
                            PhoneNumberConfirmed = false,
                            PasswordHash = password,
                            MaChucVu = request.UserRequest.MaChucVu,
                            ChiNhanhId = request.UserRequest.ChiNhanhId,
                            MaPhongBan = request.UserRequest.MaPhongBan,
                        };

                        _unitOfWork.UserRepository.Insert(nguoidung);
                        var result = await _unitOfWork.SaveAsync(cancellationToken);
                        return result > 0
                            ? new Response<UserResponse>("Thêm mới người dùng thành công")
                            : new Response<UserResponse>(Message.Error());
                    }
                    catch(Exception ex)
                    {
                        _logger.LogError(ex.Message, "Lỗi khi tạo người dùng mới");
                        return new Response<UserResponse>(Message.Error());
                    }
            
                
            }
        }
    }
}
