namespace RepairShopV2.Models
{
    public class VehicleMake
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public virtual ICollection<VehicleMake> VehicleMakes { get; } = new List<VehicleMake>();
    }
}
