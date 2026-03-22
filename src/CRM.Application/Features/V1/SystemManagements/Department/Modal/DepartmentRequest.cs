using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Features.V1.SystemManagements.Department.Modal
{
    public class DepartmentRequest
    {
        public int SoThuTu { get; set; }
        public string MaQuanLy { get; set; }
        public string TenPhongBan { get; set; }
        public string MoTa { get; set; }
        public bool IsActive { get; set; }
        public Guid ChiNhanhId  { get; set; }
    }
}
