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
        public required int CompanyId { get; set; }
        public ClientCompany? ClientCompany { get; set; }
    }
}
