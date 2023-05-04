using Shopping.DomainModel.Model;

namespace WorkShopSample1.ViewModel
{
    public class ProductImageIndexModel
    {
        public ProductImageViewModel ProductImage { get; set; }
        public List<ProductImage> Images { get; set; }

        public ProductImageIndexModel()
        {
            this.Images = new List<ProductImage>();
        }
    }
}