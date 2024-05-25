namespace RepairShopV2.Models
{
    public class ServiceCategory
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Service> Services { get; } = new List<Service>();
    }
}
