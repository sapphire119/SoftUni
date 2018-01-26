namespace ProductShop.App.Dtos.Imported
{
    public class ProductDtoImported
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? BuyerId { get; set; }
        public UserDto Buyer { get; set; }

        public int? SellerId { get; set; }
        public UserDto Seller { get; set; }
    }
}
