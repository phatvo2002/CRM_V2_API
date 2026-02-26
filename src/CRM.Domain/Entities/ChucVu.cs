using CRM.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public  partial class ChucVu : IdentityRole<Guid>
    {
        public string? MoTa {  get; set; }  

        public virtual ICollection<Nguoidung> Nguoidung { get; set;} = new List<Nguoidung>();

        public virtual ICollection<MenuRole> MenuRole { get; set; } = new List<MenuRole>();
        public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
