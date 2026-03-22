using AutoMapper;
using CRM.Application.Common.Abstractions.Data;
using CRM.Application.Features.V1.SystemManagements.Branch.Modal;
using CRM.Application.Features.V1.SystemManagements.Department.Modal;
using CRM.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CRM.Application.Features.V1.SystemManagements.Department.Command
{
    public class UpdateDepartmentCommand : IRequest<Response<bool>>
    {
        public Guid id { get; set; }
        public DepartmentRequest? DepartmentRequest { get; set; }

        public class UpdateDepartmentCommandHandle : IRequestHandler<UpdateDepartmentCommand, Response<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly ILogger<UpdateDepartmentCommandHandle> _logger;
            public UpdateDepartmentCommandHandle(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateDepartmentCommandHandle> logger)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _logger = logger;
            }
            public async Task<Response<bool>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
            {
                var data = await _unitOfWork.DepartmentRepository.GetAsync(x => x.Id == request.id);
                if (data == null)
                {
                    return new Response<bool> { Succeed = false, Data = false, Message = "Không tìm thấy dữ liệu cần cập nhật" };
                }
                try
                {
                    if (request.DepartmentRequest != null)
                    {
                        data.SoThuTu = request.DepartmentRequest.SoThuTu;
                        data.MaQuanLy  = request.DepartmentRequest.MaQuanLy;
                        data.TenPhongBan = request.DepartmentRequest.TenPhongBan;
                        data.MoTa = request.DepartmentRequest.MoTa;
                        data.IsActive = request.DepartmentRequest.IsActive;
                        data.ChiNhanhId = request.DepartmentRequest.ChiNhanhId;
                        
                    }

                    _unitOfWork.DepartmentRepository.Update(data);
                    var result = await _unitOfWork.SaveAsync();
                    if (result > 0)
                    {
                        _logger.LogInformation($"Cập nhật phòng ban có id {request.id} thành công");
                        return new Response<bool> { Succeed = true, Data = true, Message = "Dữ liệu đã được cập nhật thành công" };

                    }
                    else
                    {
                        _logger.LogError($"Cập nhật phòng ban có id  {request.id} thất bại");
                        return new Response<bool> { Succeed = false, Data = false, Message = "Đã có lỗi xảy ra trong hệ thống" };
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, Message.Error());
                    return new Response<bool> { Succeed = false, Data = false, Message = $"Lỗi : {ex.Message}" };
                }


                throw new NotImplementedException();
            }
        }
    }
}
