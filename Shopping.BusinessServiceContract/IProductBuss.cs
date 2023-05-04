using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork;
using Shopping.DomainModel.DTO.Product;
using Shopping.DomainModel.Model;

namespace Shopping.BusinessServiceContract
{
    public interface IProductBuss
    {
        OperationResult Remove(int id);
        OperationResult Register(ProductAddModel model);
        OperationResult Update(ProductUpdateModel model);
        List<ProductListItem> Search(ProductSearchModel sm , out int recordCount);
        Product GetProduct(int id);
        void AssignImageToProduct(Product product);
        List<ProductImage> GetImageList(int productId);
    }
}