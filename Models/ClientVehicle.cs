﻿namespace RepairShopV2.Models
{
    public class ClientVehicle
    {
        public int Id { get; set; }
        public int VehicleMakeId { get; set; }
        public virtual required VehicleMake VehicleMake { get; set; }
        public int VehicleModelId { get; set; }
        public virtual required VehicleModel VehicleModel { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public int ClientId { get; set; }
        public virtual required Client Client { get; set; }
        public int ClientCompanyId { get; set; }
        public virtual required ClientCompany ClientCompany { get; set; }


    }
}
