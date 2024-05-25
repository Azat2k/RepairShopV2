namespace RepairShopV2.Models
{
    public class Service
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public TimeSpan LaborHours { get; set; }
        public decimal LaborPrice { get; set; }
        public int? ServiceCategoryId { get; set; }
        public ServiceCategory? ServiceCategory { get; set; }
        public virtual ICollection<SparePart> SpareParts { get; } = new List<SparePart>();
    }
}
