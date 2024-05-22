namespace RepairShopV2.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<SparePart> SpareParts { get; } = new List<SparePart>();
    }
}
