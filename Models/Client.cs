namespace RepairShopV2.Models
{
    public class Client
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public int ClientCompanyId { get; set; }
        public ClientCompany? ClientCompany { get; set; }
        public virtual ICollection<ClientVehicle> ClientVehicles { get; } = new List<ClientVehicle>();
    }
}
