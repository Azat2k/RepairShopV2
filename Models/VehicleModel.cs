namespace RepairShopV2.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int VehicleMakeId { get; set; }
        public virtual required VehicleMake VehicleMake { get; set; }
        public virtual ICollection<ClientVehicle> ClientVehicles { get; } = new List<ClientVehicle>();

    }
}
