namespace RepairShopV2.Models
{
    public class ClientVehicle
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
