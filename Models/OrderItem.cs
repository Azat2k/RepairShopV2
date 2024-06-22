namespace RepairShopV2.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int? SparePartId { get; set; }
        public virtual SparePart SparePart { get; set; }
        public int? ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
