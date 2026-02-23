namespace Domain.Entities
{
    public class TinhTrangDonHang
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
    }
}
