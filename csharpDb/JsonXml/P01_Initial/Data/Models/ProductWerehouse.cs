namespace P01_Initial.Data.Models
{
    public class ProductWerehouse
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int WereHouseId { get; set; }
        public WereHouse WereHouse { get; set; }
    }
}