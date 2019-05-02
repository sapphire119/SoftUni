namespace ProductShop.App.Dtos.Exported
{
    public class CategoryByProductDto
    {
        public string Category { get; set; }

        public int ProductCount { get; set; }

        public decimal AveragePrice { get; set; }

        public decimal TotalRevenue { get; set; }
    }
}
