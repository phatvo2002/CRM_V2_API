using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Features.V1.SystemManagements.Branch.Modal
{
    public class BranchResponse
    {
        public string? TenChiNhanh { get; set; }
        public int SoThuTu { get; set; }
        public string? DiaChi { get; set; }
        public string? MoTa { get; set; }
        public bool? IsChiNhanhTong { get; set; }
    }
}
