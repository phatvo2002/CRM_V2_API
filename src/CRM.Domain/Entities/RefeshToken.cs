namespace Domain.Entities
{
    public class RefeshToken
    {
        public Guid Id { get; set; }
        public string? Token   { get; set; }
        public DateTime Expires { get; set; }
        public Guid NguoiDungId { get; set; }    
        public Nguoidung Nguoidung { get; set; }    
    }
}
