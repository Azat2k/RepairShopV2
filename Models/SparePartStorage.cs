namespace RepairShopV2.Models
{
    public class SparePartStorage
    {
        public int Id { get; set; }
        public int SparePartId { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
        public virtual SparePart? SparePart { get; set; }
    }
}
