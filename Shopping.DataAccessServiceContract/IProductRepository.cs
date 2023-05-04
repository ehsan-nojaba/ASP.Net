using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.DataAccess;
using Shopping.DomainModel.DTO.Product;
using Shopping.DomainModel.Model;

namespace Shopping.DataAccessServiceContract
{
    public interface IProductRepository:IBaseSearchRepository<int ,Product ,ProductSearchModel , ProductListItem , ProductAddModel , ProductUpdateModel>
    {
        bool HasProductNameExist(string productName);
        bool HasProductNameExist(string productName , int productId);
        void AssignImageToProduct(Product product);
        List<ProductImage> GetImageList(int productId);
    }
}