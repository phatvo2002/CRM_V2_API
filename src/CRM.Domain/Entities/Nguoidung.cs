using Microsoft.AspNetCore.Identity;
namespace Domain.Entities
{
    public partial class Nguoidung : IdentityUser<Guid>  {
        public string? HoVaDem { get; set; }
        public string? Ten { get; set; }
        public string? DiaChi { get; set; }
        public string? DisplayName { get; set; }
        public DateTime? NgayThuViec { get; set; }
        public DateTime? NgayBatDauLamViec { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public byte[]? HinhAnh { get; set; }
        public Guid? MaChucVu { get; set; }
        public virtual ChucVu? ChucVu { get; set; }
        public Guid? MaPhongBan { get; set; }
        public virtual PhongBan? PhongBan { get; set; }
        public  TinhTrang? TinhTrang { get; set; }
        // Chi nhánh 
        public virtual ChiNhanh? ChiNhanh { get; set; }
        public Guid? ChiNhanhId { get; set; }
        public virtual ICollection<KhachHangTiemNang> KhachHangTiemNangs { get; set; } = new List<KhachHangTiemNang>();
        public virtual ICollection<KhachHangMucTieu> KhachHangMucTieus { get; set; } = new List<KhachHangMucTieu>();
        public virtual ICollection<CoHoi> CoHois { get; set; } = new List<CoHoi>();
        public virtual ICollection<BaoGia> BaoGias { get; set; } = new List<BaoGia>();
        public virtual ICollection<CuocGoi> CuocGois { get; set; } = new List<CuocGoi>();
        public virtual ICollection<LichHen> LichHens { get; set; } = new List<LichHen>();
        public virtual ICollection<NhiemVu> NhiemVus { get; set; } = new List<NhiemVu>();
        public virtual ICollection<LienHe> LienHes { get; set; } = new List<LienHe>();
        public virtual ICollection<EmailDaGui> EmailDaGuis { get; set; } = new List<EmailDaGui>();
        public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();

        // kpi
        public virtual ICollection<MucTieuDoanhSo> MucTieuDoanhSos { get; set; } = new List<MucTieuDoanhSo>();
        public virtual ICollection<KPINhanVien> KPINhanViens { get; set; } = new List<KPINhanVien>();
        public virtual ICollection<RefeshToken> RefeshTokens { get; set; } = new List<RefeshToken>();  

    }
}
