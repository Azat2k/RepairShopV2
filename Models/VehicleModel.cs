namespace RepairShopV2.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public VehicleMake? VehicleMake { get; set; }
    }
}
