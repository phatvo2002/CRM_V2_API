using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class BaseEntity
    {
        public DateTime? CreateAt { get; set; }
        public Guid? NguoiDungId { get; set; }
        public Guid? PhongBanId { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? UpdateUser { get; set; }
        public DateTime? DeleteAt { get; set; }
        public string? DeleteUser { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual Nguoidung? Nguoidung { get; set; }
        public virtual PhongBan? PhongBan { get; set; }
    }
}
