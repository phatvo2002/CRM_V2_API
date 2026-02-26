namespace Domain.Entities
{
    public class MenuRole
    {
        public Guid MenuId { get; set; }

        public Guid GroupId { get; set; }

        public virtual Menu? Menu { get; set; }

        public virtual ChucVu? ChucVu { get; set; }
       
    }
}
