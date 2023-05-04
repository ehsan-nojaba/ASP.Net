namespace WorkShopSample1.ViewModel
{
    public class ProductImageViewModel
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public IFormFile Picture { get; set; }
        public string Alt { get; set; }
        public string Description { get; set; }
        public bool isDefault { get; set; }
    }
}