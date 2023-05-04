using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork;
using Shopping.BusinessServiceContract;
using Shopping.DataAccessServiceContract;
using Shopping.DomainModel.DTO.Product;
using Shopping.DomainModel.Model;

namespace Shopping.Business
{
    public class ProductBuss:IProductBuss
    {
        private IProductRepository repo;

        public ProductBuss(IProductRepository repo)
        {
            this.repo = repo;
        }

        public OperationResult Remove(int id)
        {
            return repo.Delete(id);
        }

        public OperationResult Register(ProductAddModel model)
        {
            if (repo.HasProductNameExist(model.ProductName))
            {
                return new OperationResult("Register", "Product").ToFail("This Category Name Exist Already");
            }

            return repo.Add(model);
        }

        public OperationResult Update(ProductUpdateModel model)
        {
            if (repo.HasProductNameExist(model.ProductName , model.ProductId))
            {
                return new OperationResult("Update" , "Product").ToFail("This Product Name Has Been Assigned to Another Product");
            }
            return repo.Update(model);
        }

        public List<ProductListItem> Search(ProductSearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }

        public Product GetProduct(int id)
        {
            return repo.Get(id);
        }

        public void AssignImageToProduct(Product product)
        { 
            repo.AssignImageToProduct(product);
        }

        public List<ProductImage> GetImageList(int productId)
        {
            return repo.GetImageList(productId);
        }
    }
}