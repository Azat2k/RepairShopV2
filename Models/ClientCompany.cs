namespace RepairShopV2.Models
{
    public class ClientCompany
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ContactName { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; } 
        public string Notes { get; set; } = string.Empty;
    }
}
