namespace RepairShopV2.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int ClientId { get; set; }
        public virtual Client? Client { get; set; }
        public int ClientVehicleId { get; set; }
        public virtual ClientVehicle? ClientVehicle { get; set; }
        //public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
    }
}
