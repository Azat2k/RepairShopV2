namespace RepairShopV2.Models
{
    public class SparePart
    {
        public int Id { get; set; }
        public int PartNumber { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal SellPrice { get; set; }
        public int? ServiceId { get; set; }
        public Service? Service { get; set; }
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public virtual ICollection<SparePartStorage> SparePartStorages { get; } = new List<SparePartStorage>();
    }
}
