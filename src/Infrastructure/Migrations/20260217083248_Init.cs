using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:tinh_trang", "cho_duyet,hoat_dong,khoa,da_xoa");

            migrationBuilder.CreateTable(
                name: "ChiNhanh",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenChiNhanh = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SoThuTu = table.Column<int>(type: "int", nullable: false),
                    DiaChi = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    MoTa = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    IsChiNhanhTong = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiNhanh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenChucVu = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MoTa = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoanhThu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenDoanhThu = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanhThu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonViTinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TiLeChuyenDoi = table.Column<int>(type: "integer", nullable: false),
                    MoTa = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViTinh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KetQuaCuocGoi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQuaCuocGoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhaoSat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NhanVienId = table.Column<Guid>(type: "uuid", maxLength: 50, nullable: true),
                    DonHangId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uuid", nullable: true),
                    KhachHangId = table.Column<string>(type: "text", nullable: true),
                    TenNhanVien = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TenKhachHang = table.Column<string>(type: "text", nullable: true),
                    TraiNghiemMuaSam = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TraiNghiemTuVan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TraiNghiemTiepTheo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DanhGiaTongThe = table.Column<int>(type: "int", nullable: false),
                    YKienKhac = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhaoSat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinhVucNgheNghiep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenLinhVuc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhVucNgheNghiep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiCoHoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiCoHoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiCuocGoi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenCuocGoi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiCuocGoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiDonHang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDonhang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiDuBao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDuBao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiHangHoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LoaiHangHoaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiHangHoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiHangHoa_LoaiHangHoa_LoaiHangHoaId",
                        column: x => x.LoaiHangHoaId,
                        principalTable: "LoaiHangHoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoaiHinhNgheNghiep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenLoaiHinh = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiHinhNgheNghiep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiTiemNang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenLoaiTiemNang = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiTiemNang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LyDo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LyDo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Icon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    OrderNumber = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Menu",
                        column: x => x.ParentId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MucDoUuTien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MucDoUuTien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguonGocKhachHang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenNguonGoc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguonGocKhachHang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhanLoaiDuBao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanLoaiDuBao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhanLoaiKhachHang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanLoaiKhachHang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhongBanKhachHang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenPhongban = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBanKhachhang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThongBao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TieuDe = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NoiDung = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Type = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    DuongDan = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IsRead = table.Column<bool>(type: "boolean", nullable: true),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    NguoiDungId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TinhTrangBaoGia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhTrangBaoGia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TinhTrangDonHang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhTrangDonHang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TinhTrangGhiDoanhSo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhTrangGhiDoanhSo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TinhTrangKPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhTrangKPI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiThucHien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiThucHien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "XepLoai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenXepLoai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TuDiem = table.Column<double>(type: "float", nullable: false),
                    DenDiem = table.Column<double>(type: "float", nullable: false),
                    MaMau = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XepLoai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhongBan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SoThuTu = table.Column<int>(type: "integer", nullable: false),
                    MaQuanLy = table.Column<string>(type: "text", nullable: true),
                    TenPhongBan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MoTa = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    ChiNhanhId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiNhanh_PhongBan",
                        column: x => x.ChiNhanhId,
                        principalTable: "ChiNhanh",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NganhNghe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenNganhNghe = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MaLinhVucNgheNghiep = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NganhNghe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NganhNghe_LinhVucNgheNghiep",
                        column: x => x.MaLinhVucNgheNghiep,
                        principalTable: "LinhVucNgheNghiep",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HangHoa",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TenHangHoa = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DuongDanHinhAnh = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MoTa = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NguonGoc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal", nullable: true),
                    MaLoaiHangHoa = table.Column<int>(type: "integer", nullable: false),
                    MaDonViTinh = table.Column<int>(type: "integer", nullable: false),
                    SoLuongTon = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoaId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonViTinh_HangHoa",
                        column: x => x.MaDonViTinh,
                        principalTable: "DonViTinh",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiHangHoa_HangHoa",
                        column: x => x.MaLoaiHangHoa,
                        principalTable: "LoaiHangHoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Menu_Group",
                columns: table => new
                {
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    Xem = table.Column<bool>(type: "boolean", nullable: true),
                    Them = table.Column<bool>(type: "boolean", nullable: true),
                    Xoa = table.Column<bool>(type: "boolean", nullable: true),
                    Sua = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Group", x => new { x.MenuId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_Menu_Role_ChucVu",
                        column: x => x.GroupId,
                        principalTable: "ChucVu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Menu_Role_Menu",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GiaiDoanBanhang",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Stt = table.Column<int>(type: "int", nullable: true),
                    TenGiaiDoan = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TiLeThanhCong = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MaLoaiDuBao = table.Column<int>(type: "integer", nullable: true),
                    MaPhanLoaiDuBao = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaiDoanBanHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaiDuBao_GiaiDoanBanHang",
                        column: x => x.MaLoaiDuBao,
                        principalTable: "LoaiDuBao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhanLoaiDuBao_GiaiDoanBanHang",
                        column: x => x.MaPhanLoaiDuBao,
                        principalTable: "PhanLoaiDuBao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HoVaDem = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Ten = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DiaChi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SoDienThoai = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DisplayName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DoanhSoDuKien = table.Column<decimal>(type: "numeric", maxLength: 50, nullable: true),
                    DoanhSoThucTe = table.Column<decimal>(type: "numeric", maxLength: 50, nullable: true),
                    NgayThuViec = table.Column<DateTime>(type: "timestamp", nullable: true),
                    NgayBatDauLamViec = table.Column<DateTime>(type: "timestamp", nullable: true),
                    TaiKhoan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MatKhau = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false),
                    CheckIsTruongPhong = table.Column<bool>(type: "boolean", nullable: false),
                    HinhAnh = table.Column<byte[]>(type: "bytea", nullable: true),
                    CheckIsGiamDoc = table.Column<bool>(type: "boolean", nullable: false),
                    CheckIsTongGiamDoc = table.Column<bool>(type: "boolean", nullable: true),
                    CheckIsSuperAdmin = table.Column<bool>(type: "boolean", nullable: true),
                    MaChucVu = table.Column<Guid>(type: "uuid", nullable: true),
                    MaPhongBan = table.Column<Guid>(type: "uuid", nullable: true),
                    TinhTrang = table.Column<TinhTrang>(type: "tinh_trang", nullable: true),
                    ChiNhanhId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiNhanh_NguoiDung",
                        column: x => x.ChiNhanhId,
                        principalTable: "ChiNhanh",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChucVu_NguoiDung",
                        column: x => x.MaChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongBan_NguoiDung",
                        column: x => x.MaPhongBan,
                        principalTable: "PhongBan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HangHoaQuanTam",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaHangHoaId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TenHangHoa = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    KhachHangTiemNangId = table.Column<Guid>(type: "uuid", nullable: true),
                    KhachHangId = table.Column<string>(type: "text", nullable: true),
                    CoHoiId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BaoGiaId = table.Column<Guid>(type: "uuid", nullable: true),
                    HoaDonId = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    ThueSuat = table.Column<int>(type: "int", nullable: true),
                    TienThue = table.Column<decimal>(type: "decimal", nullable: true),
                    ChiecKhauDonHang = table.Column<decimal>(type: "numeric", nullable: true),
                    ThanhTien = table.Column<decimal>(type: "decimal", nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal", nullable: true),
                    MaDonViTinh = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoaQuanTam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonViTinh_HangHoaQuanTam",
                        column: x => x.MaDonViTinh,
                        principalTable: "DonViTinh",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HangHoa_HangHoaQuanTam",
                        column: x => x.MaHangHoaId,
                        principalTable: "HangHoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KhachHangMucTieu",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TenKhachHang = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TenVietTat = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MaSoThue = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SoDienThoai = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    NgayThanhLap = table.Column<DateTime>(type: "date", nullable: true),
                    TaiKhoanNganHang = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Website = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MoTa = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsDungChung = table.Column<bool>(type: "boolean", nullable: true),
                    IsKhachHangCaNhan = table.Column<bool>(type: "boolean", nullable: true),
                    IsNhaPhanPhoi = table.Column<bool>(type: "boolean", nullable: true),
                    ThongTinHoaDon = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    ThongTinGiaoHang = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    MaPhongbanKhachHang = table.Column<int>(type: "integer", nullable: true),
                    MaNguonGocKhachHang = table.Column<int>(type: "integer", nullable: true),
                    MaLoaiTiemNang = table.Column<int>(type: "integer", nullable: true),
                    MaLoaiHinhNgheNghiep = table.Column<int>(type: "integer", nullable: true),
                    MaNganhNghe = table.Column<int>(type: "integer", nullable: true),
                    MaLinhVuc = table.Column<int>(type: "integer", nullable: true),
                    MaDoanhThu = table.Column<int>(type: "integer", nullable: true),
                    MaPhanLoaiKhachHang = table.Column<int>(type: "integer", nullable: true),
                    NamGuiMailSinhNhat = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    NguoiDungId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UpdateUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeleteUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangMucTieu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoanhThu_KhachHangMucTieu",
                        column: x => x.MaDoanhThu,
                        principalTable: "DoanhThu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LinhVuc_KhachHangMucTieu",
                        column: x => x.MaLinhVuc,
                        principalTable: "LinhVucNgheNghiep",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiHinhNgheNghiep_KhachHangMucTieu",
                        column: x => x.MaLoaiHinhNgheNghiep,
                        principalTable: "LoaiHinhNgheNghiep",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiTiemNang_KhachHangMucTieu",
                        column: x => x.MaLoaiTiemNang,
                        principalTable: "LoaiTiemNang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NganhNghe_KhachHangMucTieu",
                        column: x => x.MaNganhNghe,
                        principalTable: "NganhNghe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NguoiDung_KhachHangMucTieu",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NguonGocKhachHang_KhachHangMucTieu",
                        column: x => x.MaNguonGocKhachHang,
                        principalTable: "NguonGocKhachHang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhanLoaiKhachHang_KhachHangMucTieu",
                        column: x => x.MaPhanLoaiKhachHang,
                        principalTable: "PhanLoaiKhachHang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongBanKhachhang_KhachHangMucTieu",
                        column: x => x.MaPhongbanKhachHang,
                        principalTable: "PhongBanKhachHang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongBan_KhachHangMucTieu",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KhachHangTiemNang",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenKhachHang = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SoDienThoaiDiDong = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    SoDienThoaiCoQuan = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    ChucDanh = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SoZalo = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    EmailCaNhan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    EmailCoQuan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TenToChuc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MaSoThue = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    NgayThanhLap = table.Column<DateTime>(type: "date", nullable: true),
                    DiaChi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ThongTinMoTa = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    MaPhongbanKhachHang = table.Column<int>(type: "integer", nullable: true),
                    MaNguonGocKhachHang = table.Column<int>(type: "integer", nullable: true),
                    MaLoaiTiemNang = table.Column<int>(type: "integer", nullable: true),
                    MaLoaiHinhNgheNghiep = table.Column<int>(type: "integer", nullable: true),
                    MaNganhNghe = table.Column<int>(type: "integer", nullable: true),
                    MaLinhVuc = table.Column<int>(type: "integer", nullable: true),
                    MaDoanhThu = table.Column<int>(type: "integer", nullable: true),
                    IsDungChung = table.Column<bool>(type: "boolean", nullable: true),
                    IsChuyenDoi = table.Column<bool>(type: "boolean", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    NguoiDungId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UpdateUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeleteUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangTiemNang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoanhThu_KhachHangTiemNang",
                        column: x => x.MaDoanhThu,
                        principalTable: "DoanhThu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LinhVuc_KhachHangTiemNang",
                        column: x => x.MaLinhVuc,
                        principalTable: "LinhVucNgheNghiep",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiHinhNgheNghiep_KhachHangTiemNang",
                        column: x => x.MaLoaiHinhNgheNghiep,
                        principalTable: "LoaiHinhNgheNghiep",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiTiemNang_KhachHangTiemNang",
                        column: x => x.MaLoaiTiemNang,
                        principalTable: "LoaiTiemNang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NganhNghe_KhachHangTiemNang",
                        column: x => x.MaNganhNghe,
                        principalTable: "NganhNghe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NguoiDung_KhachHangTiemNang",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NguonGocKhachHang_KhachHangTiemNang",
                        column: x => x.MaNguonGocKhachHang,
                        principalTable: "NguonGocKhachHang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongBanKhachhang_KhachHangTiemNang",
                        column: x => x.MaPhongbanKhachHang,
                        principalTable: "PhongBanKhachHang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongBan_KhachHangTiemNang",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LienHe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TenLienHe = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    XungHo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SoDienThoai = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    KhachHangTiemNangId = table.Column<Guid>(type: "uuid", nullable: true),
                    KhachHangId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    NguoiDungId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UpdateUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteUser = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LienHe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiDung_LienHe",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongBan_PhongBan",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MucTieuDoanhSo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenKPI = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MaQuanLy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TenPhongBan = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "timestamp", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "timestamp", nullable: true),
                    SoCuocGoi = table.Column<int>(type: "int", nullable: true),
                    SoCuocGoiThucTe = table.Column<int>(type: "int", nullable: true),
                    TileCuocGoiThucTe = table.Column<decimal>(type: "decimal", nullable: true),
                    SoLichHen = table.Column<int>(type: "int", nullable: true),
                    SoLichHenThucTe = table.Column<int>(type: "int", nullable: true),
                    TileLichHenThucTe = table.Column<decimal>(type: "decimal", nullable: true),
                    SoEmailTuongTacKhachHang = table.Column<int>(type: "int", nullable: true),
                    SoEmailTruongTacKhachHangThucTe = table.Column<int>(type: "int", nullable: true),
                    TileEmailTuongTacThucTe = table.Column<decimal>(type: "decimal", nullable: true),
                    SoEmailBaoGia = table.Column<int>(type: "integer", nullable: true),
                    SoEmailBaoGiaThucTe = table.Column<int>(type: "integer", nullable: true),
                    TiLeEmailBaoGiaThucTe = table.Column<decimal>(type: "numeric", nullable: true),
                    SoKhachHangTiemNangDaChuyenDoi = table.Column<int>(type: "int", nullable: true),
                    SoKhachHangTiemNangDaChuyenDoiThucTe = table.Column<int>(type: "int", nullable: true),
                    TiLeSoKhachHangTiemNangDaChuyenDoiThucTe = table.Column<decimal>(type: "decimal", nullable: true),
                    DoanhSo = table.Column<int>(type: "int", nullable: true),
                    DoanhSoThucTe = table.Column<int>(type: "int", nullable: true),
                    TiLeDoanhSoThucTe = table.Column<decimal>(type: "decimal", nullable: true),
                    IsDatMucTieu = table.Column<bool>(type: "boolean", nullable: true),
                    MaTrangThaiKPI = table.Column<int>(type: "integer", nullable: true),
                    TongTiLeThucTe = table.Column<decimal>(type: "decimal", nullable: true),
                    NguoiTaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    TenNguoiTao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    NguoiDungId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UpdateUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MucTieuDoanhSoId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiDung_MucTieuDoanhSo",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongBan_MucTieuDoanhSo",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TinhTrangKPI_MucTieuDoanhSo",
                        column: x => x.MaTrangThaiKPI,
                        principalTable: "TinhTrangKPI",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RefeshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Expires = table.Column<DateTime>(type: "timestamp", nullable: false),
                    NguoiDungId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefeshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefeshToken",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmailDaGui",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TieuDe = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DiaChiGui = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DiaChiNhan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    KhachHangTiemNangId = table.Column<Guid>(type: "uuid", nullable: true),
                    KhachHangMucTieuId = table.Column<string>(type: "text", nullable: true),
                    BaoGiaId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NguoiDungId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateUser = table.Column<string>(type: "text", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteUser = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailDaGui", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhachHangMucTieu_EmailDaGui",
                        column: x => x.KhachHangMucTieuId,
                        principalTable: "KhachHangMucTieu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KhachHangTiemNang_EmailDaGui",
                        column: x => x.KhachHangTiemNangId,
                        principalTable: "KhachHangTiemNang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NguoiDung_EmailDaGui",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongBan_EmailDaGui",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CoHoi",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TenCoHoi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SoTien = table.Column<decimal>(type: "decimal", nullable: true),
                    TiLeThanhCong = table.Column<int>(type: "integer", nullable: true),
                    DoanhSoKyVong = table.Column<decimal>(type: "numeric", nullable: true),
                    NgayKyVongKetThuc = table.Column<DateTime>(type: "timestamp", nullable: true),
                    MaKhachHang = table.Column<string>(type: "text", nullable: true),
                    MaLienHe = table.Column<string>(type: "text", nullable: true),
                    MaLoaiHangHoa = table.Column<int>(type: "integer", nullable: true),
                    MaLoaiCoHoi = table.Column<int>(type: "integer", nullable: true),
                    MaGiaiDoanBanHang = table.Column<Guid>(type: "uuid", nullable: true),
                    MaNguonGocKhachHang = table.Column<int>(type: "integer", nullable: true),
                    DiaChi = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    NguoiDungId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UpdateUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeleteUser = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoHoi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiaiDoanBanHang_CoHoi",
                        column: x => x.MaGiaiDoanBanHang,
                        principalTable: "GiaiDoanBanhang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KhachHangMucTieu_CoHoi",
                        column: x => x.MaKhachHang,
                        principalTable: "KhachHangMucTieu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LienHe_CoHoi",
                        column: x => x.MaLienHe,
                        principalTable: "LienHe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiCoHoi_CoHoi",
                        column: x => x.MaLoaiCoHoi,
                        principalTable: "LoaiCoHoi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiHangHoa_CoHoi",
                        column: x => x.MaLoaiHangHoa,
                        principalTable: "LoaiHangHoa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NguoiDung_CoHoi",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NguonGocKhachHang_CoHoi",
                        column: x => x.MaNguonGocKhachHang,
                        principalTable: "NguonGocKhachHang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongBan_CoHoi",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaQuanLy = table.Column<string>(type: "text", nullable: true),
                    TenDonHang = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MoTaDonHang = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    NgayDatHang = table.Column<DateTime>(type: "timestamp", nullable: true),
                    GiaTriDonHang = table.Column<decimal>(type: "decimal", nullable: false),
                    SoTienConPhaiThu = table.Column<decimal>(type: "numeric", nullable: false),
                    ThucThuDonHang = table.Column<decimal>(type: "numeric", nullable: false),
                    HanThanhToan = table.Column<DateTime>(type: "timestamp", nullable: true),
                    HanGiaoHang = table.Column<DateTime>(type: "timestamp", nullable: true),
                    NgayGhiDoanhSo = table.Column<DateTime>(type: "timestamp", nullable: true),
                    MaLoaiDonHang = table.Column<int>(type: "integer", nullable: false),
                    MaBaoGia = table.Column<Guid>(type: "uuid", nullable: true),
                    MaKhachHang = table.Column<string>(type: "text", nullable: true),
                    MaLienHe = table.Column<string>(type: "text", nullable: true),
                    MaTinhTrangDonHang = table.Column<int>(type: "integer", nullable: true),
                    MaTinhTrangGhiDoanhSo = table.Column<int>(type: "integer", nullable: true),
                    IsGhiDoanhSo = table.Column<bool>(type: "boolean", nullable: false),
                    ThongTinHoaDon = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    ThongTinGiaoHang = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    PhuongThucThanhToan = table.Column<string>(type: "text", nullable: true),
                    SoTaiKhoanNganHang = table.Column<string>(type: "text", nullable: true),
                    ChuTaiKhoan = table.Column<string>(type: "text", nullable: true),
                    LyDoHuyDon = table.Column<string>(type: "text", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    NguoiDungId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UpdateUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhachHangMucTieu_DonHang",
                        column: x => x.MaKhachHang,
                        principalTable: "KhachHangMucTieu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LienHe_DonHang",
                        column: x => x.MaLienHe,
                        principalTable: "LienHe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiDonHang_DonHang",
                        column: x => x.MaLoaiDonHang,
                        principalTable: "LoaiDonHang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NguoiDung_DonHang",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongBan_DonHang",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TinhTrangDonHang_DonHang",
                        column: x => x.MaTinhTrangDonHang,
                        principalTable: "TinhTrangDonHang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TinhTrangGhiDoanhSo_DonHang",
                        column: x => x.MaTinhTrangGhiDoanhSo,
                        principalTable: "TinhTrangGhiDoanhSo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KPINhanVien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenKPI = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MaQuanLy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TenNhanVien = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "timestamp", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "timestamp", nullable: true),
                    SoCuocGoi = table.Column<int>(type: "int", nullable: true),
                    SoCuocGoiThucTe = table.Column<int>(type: "int", nullable: true),
                    TileCuocGoiThucTe = table.Column<decimal>(type: "decimal", nullable: true),
                    SoLichHen = table.Column<int>(type: "int", nullable: true),
                    SoLichHenThucTe = table.Column<int>(type: "int", nullable: true),
                    TileLichHenThucTe = table.Column<decimal>(type: "decimal", nullable: true),
                    SoEmailTuongTacKhachHang = table.Column<int>(type: "int", nullable: true),
                    SoEmailTruongTacKhachHangThucTe = table.Column<int>(type: "int", nullable: true),
                    TileEmailTuongTacThucTe = table.Column<decimal>(type: "decimal", nullable: true),
                    SoEmailBaoGia = table.Column<int>(type: "integer", nullable: true),
                    SoEmailBaoGiaThucTe = table.Column<int>(type: "integer", nullable: true),
                    TiLeEmailBaoGiaThucTe = table.Column<decimal>(type: "numeric", nullable: true),
                    SoKhachHangTiemNangDaChuyenDoi = table.Column<int>(type: "int", nullable: true),
                    SoKhachHangTiemNangDaChuyenDoiThucTe = table.Column<int>(type: "int", nullable: true),
                    TiLeSoKhachHangTiemNangDaChuyenDoiThucTe = table.Column<decimal>(type: "decimal", nullable: true),
                    DoanhSo = table.Column<int>(type: "int", nullable: true),
                    DoanhSoThucTe = table.Column<int>(type: "int", nullable: true),
                    TiLeDoanhSoThucTe = table.Column<decimal>(type: "decimal", nullable: true),
                    IsDatMucTieu = table.Column<bool>(type: "boolean", nullable: true),
                    MaTrangThaiKPI = table.Column<int>(type: "integer", nullable: true),
                    GhiChu = table.Column<string>(type: "text", nullable: true),
                    MaMucTieuDoanhSo = table.Column<Guid>(type: "uuid", nullable: true),
                    TongTiLeThucTe = table.Column<decimal>(type: "decimal", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    NguoiDungId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UpdateUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KPINhanVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MucTieuDoanhSo_KPINhanVien",
                        column: x => x.MaMucTieuDoanhSo,
                        principalTable: "MucTieuDoanhSo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NguoiDung_KPINhanVien",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongBan_KPINhanVien",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TinhTrangKPI_KPINhanVien",
                        column: x => x.MaTrangThaiKPI,
                        principalTable: "TinhTrangKPI",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BaoGia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenBaoGia = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    NgayBaoGia = table.Column<DateTime>(type: "timestamp", nullable: true),
                    NgayHetHan = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DiaChi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MaSoThue = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MoTa = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal", nullable: true),
                    MaTinhTrangBaoGia = table.Column<int>(type: "integer", nullable: true),
                    MaCoHoi = table.Column<string>(type: "text", nullable: true),
                    MaKhachHang = table.Column<string>(type: "text", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NguoiDungId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UpdateUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteUser = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoGia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoHoi_BaoGia",
                        column: x => x.MaCoHoi,
                        principalTable: "CoHoi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KhachHang_BaoGia",
                        column: x => x.MaKhachHang,
                        principalTable: "KhachHangMucTieu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NguoiDung_BaoGia",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongBan_BaoGia",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TinhTrangBaoGia_BaoGia",
                        column: x => x.MaTinhTrangBaoGia,
                        principalTable: "TinhTrangBaoGia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKetQua",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal", nullable: true),
                    NgayKyVongKetThuc = table.Column<DateTime>(type: "timestamp", nullable: false),
                    MaCoHoi = table.Column<string>(type: "text", nullable: true),
                    MaGiaiDoan = table.Column<Guid>(type: "uuid", nullable: true),
                    MaLyDo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietKetQua", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoHoi_ChiTietKetQua",
                        column: x => x.MaCoHoi,
                        principalTable: "CoHoi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GiaiDoanBanHang_ChiTietKetQua",
                        column: x => x.MaGiaiDoan,
                        principalTable: "GiaiDoanBanhang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LyDo_ChiTietKetQua",
                        column: x => x.MaLyDo,
                        principalTable: "LyDo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CuocGoi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TieuDe = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MoTa = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "timestamp", nullable: true),
                    SoPhutGoi = table.Column<int>(type: "int", nullable: true),
                    SoGiayGoi = table.Column<int>(type: "int", nullable: true),
                    IsHoanThanh = table.Column<bool>(type: "boolean", nullable: true),
                    LoaiCuocGoiId = table.Column<Guid>(type: "uuid", nullable: true),
                    KhachHangTiemNangId = table.Column<Guid>(type: "uuid", nullable: true),
                    KetQuaCuocGoiId = table.Column<Guid>(type: "uuid", nullable: true),
                    KhachHangMucTieuId = table.Column<string>(type: "text", nullable: true),
                    CoHoiId = table.Column<string>(type: "text", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    NguoiDungId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UpdateUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuocGoi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoHoi_CuocGoi",
                        column: x => x.CoHoiId,
                        principalTable: "CoHoi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KHMucTieu_CuocGoi",
                        column: x => x.KhachHangMucTieuId,
                        principalTable: "KhachHangMucTieu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KHTiemNang_CuocGoi",
                        column: x => x.KhachHangTiemNangId,
                        principalTable: "KhachHangTiemNang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KetQuaCuocGoi_CuocGoi",
                        column: x => x.KetQuaCuocGoiId,
                        principalTable: "KetQuaCuocGoi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoaiCuocGoi_CuocGoi",
                        column: x => x.LoaiCuocGoiId,
                        principalTable: "LoaiCuocGoi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NguoiDung_CuocGoi",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongBan_CuocGoi",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LichHen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TieuDe = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MoTa = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "date", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "date", nullable: true),
                    DiaDiem = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TrangThaiThucHienId = table.Column<Guid>(type: "uuid", nullable: true),
                    KhachHangTiemNangId = table.Column<Guid>(type: "uuid", nullable: true),
                    KhachHangMucTieuId = table.Column<string>(type: "text", nullable: true),
                    CoHoiId = table.Column<string>(type: "text", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    NguoiDungId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UpdateUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichHen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoHoi_LichHen",
                        column: x => x.CoHoiId,
                        principalTable: "CoHoi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KHMucTieu_LichHen",
                        column: x => x.KhachHangMucTieuId,
                        principalTable: "KhachHangMucTieu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KhachHangTiemNang_LichHen",
                        column: x => x.KhachHangTiemNangId,
                        principalTable: "KhachHangTiemNang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NguoiDung_LichHen",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongBan_LichHen",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrangThaiThucHien_LichHen",
                        column: x => x.TrangThaiThucHienId,
                        principalTable: "TrangThaiThucHien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NhiemVu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TieuDe = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MoTa = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IsThongBao = table.Column<bool>(type: "boolean", nullable: true),
                    IsGuiMail = table.Column<bool>(type: "boolean", nullable: true),
                    HanHoanThanh = table.Column<DateTime>(type: "timestamp", nullable: true),
                    KhachHangTiemNangId = table.Column<Guid>(type: "uuid", nullable: true),
                    MucDoUuTienId = table.Column<Guid>(type: "uuid", nullable: true),
                    TrangThaiThucHienId = table.Column<Guid>(type: "uuid", nullable: true),
                    KhachHangMucTieuId = table.Column<string>(type: "text", nullable: true),
                    CoHoiId = table.Column<string>(type: "text", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NguoiDungId = table.Column<Guid>(type: "uuid", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UpdateUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteUser = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhiemVu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoHoi_NhiemVu",
                        column: x => x.CoHoiId,
                        principalTable: "CoHoi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KhachHangMucTieu_NhiemVu",
                        column: x => x.KhachHangMucTieuId,
                        principalTable: "KhachHangMucTieu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KhachHangTiemNang_NhiemVu",
                        column: x => x.KhachHangTiemNangId,
                        principalTable: "KhachHangTiemNang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MucDoUuTien_NhiemVu",
                        column: x => x.MucDoUuTienId,
                        principalTable: "MucDoUuTien",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NguoiDung_NhiemVu",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhongBan_NhiemVu",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrangThaiThucHien_NhiemVu",
                        column: x => x.TrangThaiThucHienId,
                        principalTable: "TrangThaiThucHien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietBaoGia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenHangHoa = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SoLuong = table.Column<int>(type: "integer", maxLength: 50, nullable: true),
                    DonGia = table.Column<decimal>(type: "numeric", maxLength: 50, nullable: true),
                    ThanhTien = table.Column<decimal>(type: "numeric", maxLength: 50, nullable: true),
                    BaoGiaId = table.Column<Guid>(type: "uuid", nullable: false),
                    KhachHangId = table.Column<string>(type: "text", nullable: true),
                    MaHangHoaId = table.Column<string>(type: "text", nullable: true),
                    MaDonViTinh = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietBaoGia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietBaoGia_BaoGia",
                        column: x => x.BaoGiaId,
                        principalTable: "BaoGia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DonViTinh_BaoGia",
                        column: x => x.MaDonViTinh,
                        principalTable: "DonViTinh",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HangHoa_BaoGia",
                        column: x => x.MaHangHoaId,
                        principalTable: "HangHoa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KhachHangMucTieu_BaoGia",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHangMucTieu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaoGia_MaCoHoi",
                table: "BaoGia",
                column: "MaCoHoi");

            migrationBuilder.CreateIndex(
                name: "IX_BaoGia_MaKhachHang",
                table: "BaoGia",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_BaoGia_MaTinhTrangBaoGia",
                table: "BaoGia",
                column: "MaTinhTrangBaoGia");

            migrationBuilder.CreateIndex(
                name: "IX_BaoGia_NguoiDungId",
                table: "BaoGia",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_BaoGia_PhongBanId",
                table: "BaoGia",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietBaoGia_BaoGiaId",
                table: "ChiTietBaoGia",
                column: "BaoGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietBaoGia_KhachHangId",
                table: "ChiTietBaoGia",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietBaoGia_MaDonViTinh",
                table: "ChiTietBaoGia",
                column: "MaDonViTinh");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietBaoGia_MaHangHoaId",
                table: "ChiTietBaoGia",
                column: "MaHangHoaId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKetQua_MaCoHoi",
                table: "ChiTietKetQua",
                column: "MaCoHoi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKetQua_MaGiaiDoan",
                table: "ChiTietKetQua",
                column: "MaGiaiDoan");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKetQua_MaLyDo",
                table: "ChiTietKetQua",
                column: "MaLyDo");

            migrationBuilder.CreateIndex(
                name: "IX_CoHoi_MaGiaiDoanBanHang",
                table: "CoHoi",
                column: "MaGiaiDoanBanHang");

            migrationBuilder.CreateIndex(
                name: "IX_CoHoi_MaKhachHang",
                table: "CoHoi",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_CoHoi_MaLienHe",
                table: "CoHoi",
                column: "MaLienHe");

            migrationBuilder.CreateIndex(
                name: "IX_CoHoi_MaLoaiCoHoi",
                table: "CoHoi",
                column: "MaLoaiCoHoi");

            migrationBuilder.CreateIndex(
                name: "IX_CoHoi_MaLoaiHangHoa",
                table: "CoHoi",
                column: "MaLoaiHangHoa");

            migrationBuilder.CreateIndex(
                name: "IX_CoHoi_MaNguonGocKhachHang",
                table: "CoHoi",
                column: "MaNguonGocKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_CoHoi_NguoiDungId",
                table: "CoHoi",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_CoHoi_PhongBanId",
                table: "CoHoi",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_CuocGoi_CoHoiId",
                table: "CuocGoi",
                column: "CoHoiId");

            migrationBuilder.CreateIndex(
                name: "IX_CuocGoi_KetQuaCuocGoiId",
                table: "CuocGoi",
                column: "KetQuaCuocGoiId");

            migrationBuilder.CreateIndex(
                name: "IX_CuocGoi_KhachHangMucTieuId",
                table: "CuocGoi",
                column: "KhachHangMucTieuId");

            migrationBuilder.CreateIndex(
                name: "IX_CuocGoi_KhachHangTiemNangId",
                table: "CuocGoi",
                column: "KhachHangTiemNangId");

            migrationBuilder.CreateIndex(
                name: "IX_CuocGoi_LoaiCuocGoiId",
                table: "CuocGoi",
                column: "LoaiCuocGoiId");

            migrationBuilder.CreateIndex(
                name: "IX_CuocGoi_NguoiDungId",
                table: "CuocGoi",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_CuocGoi_PhongBanId",
                table: "CuocGoi",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_MaKhachHang",
                table: "DonHang",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_MaLienHe",
                table: "DonHang",
                column: "MaLienHe");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_MaLoaiDonHang",
                table: "DonHang",
                column: "MaLoaiDonHang");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_MaTinhTrangDonHang",
                table: "DonHang",
                column: "MaTinhTrangDonHang");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_MaTinhTrangGhiDoanhSo",
                table: "DonHang",
                column: "MaTinhTrangGhiDoanhSo");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_NguoiDungId",
                table: "DonHang",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_PhongBanId",
                table: "DonHang",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailDaGui_KhachHangMucTieuId",
                table: "EmailDaGui",
                column: "KhachHangMucTieuId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailDaGui_KhachHangTiemNangId",
                table: "EmailDaGui",
                column: "KhachHangTiemNangId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailDaGui_NguoiDungId",
                table: "EmailDaGui",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailDaGui_PhongBanId",
                table: "EmailDaGui",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_GiaiDoanBanhang_MaLoaiDuBao",
                table: "GiaiDoanBanhang",
                column: "MaLoaiDuBao");

            migrationBuilder.CreateIndex(
                name: "IX_GiaiDoanBanhang_MaPhanLoaiDuBao",
                table: "GiaiDoanBanhang",
                column: "MaPhanLoaiDuBao");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaDonViTinh",
                table: "HangHoa",
                column: "MaDonViTinh");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaLoaiHangHoa",
                table: "HangHoa",
                column: "MaLoaiHangHoa");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoaQuanTam_MaDonViTinh",
                table: "HangHoaQuanTam",
                column: "MaDonViTinh");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoaQuanTam_MaHangHoaId",
                table: "HangHoaQuanTam",
                column: "MaHangHoaId");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangMucTieu_MaDoanhThu",
                table: "KhachHangMucTieu",
                column: "MaDoanhThu");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangMucTieu_MaLinhVuc",
                table: "KhachHangMucTieu",
                column: "MaLinhVuc");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangMucTieu_MaLoaiHinhNgheNghiep",
                table: "KhachHangMucTieu",
                column: "MaLoaiHinhNgheNghiep");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangMucTieu_MaLoaiTiemNang",
                table: "KhachHangMucTieu",
                column: "MaLoaiTiemNang");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangMucTieu_MaNganhNghe",
                table: "KhachHangMucTieu",
                column: "MaNganhNghe");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangMucTieu_MaNguonGocKhachHang",
                table: "KhachHangMucTieu",
                column: "MaNguonGocKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangMucTieu_MaPhanLoaiKhachHang",
                table: "KhachHangMucTieu",
                column: "MaPhanLoaiKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangMucTieu_MaPhongbanKhachHang",
                table: "KhachHangMucTieu",
                column: "MaPhongbanKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangMucTieu_NguoiDungId",
                table: "KhachHangMucTieu",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangMucTieu_PhongBanId",
                table: "KhachHangMucTieu",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangTiemNang_MaDoanhThu",
                table: "KhachHangTiemNang",
                column: "MaDoanhThu");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangTiemNang_MaLinhVuc",
                table: "KhachHangTiemNang",
                column: "MaLinhVuc");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangTiemNang_MaLoaiHinhNgheNghiep",
                table: "KhachHangTiemNang",
                column: "MaLoaiHinhNgheNghiep");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangTiemNang_MaLoaiTiemNang",
                table: "KhachHangTiemNang",
                column: "MaLoaiTiemNang");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangTiemNang_MaNganhNghe",
                table: "KhachHangTiemNang",
                column: "MaNganhNghe");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangTiemNang_MaNguonGocKhachHang",
                table: "KhachHangTiemNang",
                column: "MaNguonGocKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangTiemNang_MaPhongbanKhachHang",
                table: "KhachHangTiemNang",
                column: "MaPhongbanKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangTiemNang_NguoiDungId",
                table: "KhachHangTiemNang",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangTiemNang_PhongBanId",
                table: "KhachHangTiemNang",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_KPINhanVien_MaMucTieuDoanhSo",
                table: "KPINhanVien",
                column: "MaMucTieuDoanhSo");

            migrationBuilder.CreateIndex(
                name: "IX_KPINhanVien_MaTrangThaiKPI",
                table: "KPINhanVien",
                column: "MaTrangThaiKPI");

            migrationBuilder.CreateIndex(
                name: "IX_KPINhanVien_NguoiDungId",
                table: "KPINhanVien",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_KPINhanVien_PhongBanId",
                table: "KPINhanVien",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_LichHen_CoHoiId",
                table: "LichHen",
                column: "CoHoiId");

            migrationBuilder.CreateIndex(
                name: "IX_LichHen_KhachHangMucTieuId",
                table: "LichHen",
                column: "KhachHangMucTieuId");

            migrationBuilder.CreateIndex(
                name: "IX_LichHen_KhachHangTiemNangId",
                table: "LichHen",
                column: "KhachHangTiemNangId");

            migrationBuilder.CreateIndex(
                name: "IX_LichHen_NguoiDungId",
                table: "LichHen",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_LichHen_PhongBanId",
                table: "LichHen",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_LichHen_TrangThaiThucHienId",
                table: "LichHen",
                column: "TrangThaiThucHienId");

            migrationBuilder.CreateIndex(
                name: "IX_LienHe_NguoiDungId",
                table: "LienHe",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_LienHe_PhongBanId",
                table: "LienHe",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiHangHoa_LoaiHangHoaId",
                table: "LoaiHangHoa",
                column: "LoaiHangHoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ParentId",
                table: "Menu",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Group_GroupId",
                table: "Menu_Group",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MucTieuDoanhSo_MaTrangThaiKPI",
                table: "MucTieuDoanhSo",
                column: "MaTrangThaiKPI");

            migrationBuilder.CreateIndex(
                name: "IX_MucTieuDoanhSo_NguoiDungId",
                table: "MucTieuDoanhSo",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_MucTieuDoanhSo_PhongBanId",
                table: "MucTieuDoanhSo",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_NganhNghe_MaLinhVucNgheNghiep",
                table: "NganhNghe",
                column: "MaLinhVucNgheNghiep");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_ChiNhanhId",
                table: "NguoiDung",
                column: "ChiNhanhId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_MaChucVu",
                table: "NguoiDung",
                column: "MaChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_MaPhongBan",
                table: "NguoiDung",
                column: "MaPhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_NhiemVu_CoHoiId",
                table: "NhiemVu",
                column: "CoHoiId");

            migrationBuilder.CreateIndex(
                name: "IX_NhiemVu_KhachHangMucTieuId",
                table: "NhiemVu",
                column: "KhachHangMucTieuId");

            migrationBuilder.CreateIndex(
                name: "IX_NhiemVu_KhachHangTiemNangId",
                table: "NhiemVu",
                column: "KhachHangTiemNangId");

            migrationBuilder.CreateIndex(
                name: "IX_NhiemVu_MucDoUuTienId",
                table: "NhiemVu",
                column: "MucDoUuTienId");

            migrationBuilder.CreateIndex(
                name: "IX_NhiemVu_NguoiDungId",
                table: "NhiemVu",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_NhiemVu_PhongBanId",
                table: "NhiemVu",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_NhiemVu_TrangThaiThucHienId",
                table: "NhiemVu",
                column: "TrangThaiThucHienId");

            migrationBuilder.CreateIndex(
                name: "IX_PhongBan_ChiNhanhId",
                table: "PhongBan",
                column: "ChiNhanhId");

            migrationBuilder.CreateIndex(
                name: "IX_RefeshToken_NguoiDungId",
                table: "RefeshToken",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_RefeshToken_Token",
                table: "RefeshToken",
                column: "Token",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietBaoGia");

            migrationBuilder.DropTable(
                name: "ChiTietKetQua");

            migrationBuilder.DropTable(
                name: "CuocGoi");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "EmailDaGui");

            migrationBuilder.DropTable(
                name: "HangHoaQuanTam");

            migrationBuilder.DropTable(
                name: "KhaoSat");

            migrationBuilder.DropTable(
                name: "KPINhanVien");

            migrationBuilder.DropTable(
                name: "LichHen");

            migrationBuilder.DropTable(
                name: "Menu_Group");

            migrationBuilder.DropTable(
                name: "NhiemVu");

            migrationBuilder.DropTable(
                name: "RefeshToken");

            migrationBuilder.DropTable(
                name: "ThongBao");

            migrationBuilder.DropTable(
                name: "XepLoai");

            migrationBuilder.DropTable(
                name: "BaoGia");

            migrationBuilder.DropTable(
                name: "LyDo");

            migrationBuilder.DropTable(
                name: "KetQuaCuocGoi");

            migrationBuilder.DropTable(
                name: "LoaiCuocGoi");

            migrationBuilder.DropTable(
                name: "LoaiDonHang");

            migrationBuilder.DropTable(
                name: "TinhTrangDonHang");

            migrationBuilder.DropTable(
                name: "TinhTrangGhiDoanhSo");

            migrationBuilder.DropTable(
                name: "HangHoa");

            migrationBuilder.DropTable(
                name: "MucTieuDoanhSo");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "KhachHangTiemNang");

            migrationBuilder.DropTable(
                name: "MucDoUuTien");

            migrationBuilder.DropTable(
                name: "TrangThaiThucHien");

            migrationBuilder.DropTable(
                name: "CoHoi");

            migrationBuilder.DropTable(
                name: "TinhTrangBaoGia");

            migrationBuilder.DropTable(
                name: "DonViTinh");

            migrationBuilder.DropTable(
                name: "TinhTrangKPI");

            migrationBuilder.DropTable(
                name: "GiaiDoanBanhang");

            migrationBuilder.DropTable(
                name: "KhachHangMucTieu");

            migrationBuilder.DropTable(
                name: "LienHe");

            migrationBuilder.DropTable(
                name: "LoaiCoHoi");

            migrationBuilder.DropTable(
                name: "LoaiHangHoa");

            migrationBuilder.DropTable(
                name: "LoaiDuBao");

            migrationBuilder.DropTable(
                name: "PhanLoaiDuBao");

            migrationBuilder.DropTable(
                name: "DoanhThu");

            migrationBuilder.DropTable(
                name: "LoaiHinhNgheNghiep");

            migrationBuilder.DropTable(
                name: "LoaiTiemNang");

            migrationBuilder.DropTable(
                name: "NganhNghe");

            migrationBuilder.DropTable(
                name: "NguonGocKhachHang");

            migrationBuilder.DropTable(
                name: "PhanLoaiKhachHang");

            migrationBuilder.DropTable(
                name: "PhongBanKhachHang");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "LinhVucNgheNghiep");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "PhongBan");

            migrationBuilder.DropTable(
                name: "ChiNhanh");
        }
    }
}
