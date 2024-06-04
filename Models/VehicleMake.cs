namespace RepairShopV2.Models
{
    public class VehicleMake
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public virtual ICollection<VehicleModel> VehicleModels { get; } = new List<VehicleModel>();
        public virtual ICollection<ClientVehicle> ClientVehicles { get; } = new List<ClientVehicle>();
    }
}
