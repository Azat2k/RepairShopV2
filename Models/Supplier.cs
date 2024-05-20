namespace RepairShopV2.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public virtual ICollection<SparePart> SpareParts { get; } = new List<SparePart>();
    }
}
