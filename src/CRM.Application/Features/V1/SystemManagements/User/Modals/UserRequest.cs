using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Features.V1.SystemManagements.User.Modals
{
    public class UserRequest
    {
        public string? HoVaDem { get; set; }
        public string? Ten { get; set; }
        public string? DiaChi { get; set; }
        public string? DisplayName { get; set; }
        public DateTime? NgayThuViec { get; set; }
        public DateTime? NgayBatDauLamViec { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public byte[]? HinhAnh { get; set; }
    }
}
