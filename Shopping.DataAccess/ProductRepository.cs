using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork;
using Shopping.DataAccessServiceContract;
using Shopping.DomainModel.DTO.Product;
using Shopping.DomainModel.Model;

namespace Shopping.DataAccess
{
    public class ProductRepository:IProductRepository
    {
        private WorkShopDevelopContext db;

        public ProductRepository(WorkShopDevelopContext db)
        {
            this.db = db;
        }

        public Product Get(int modelId)
        {
            return db.Products.FirstOrDefault(x => x.ProductId == modelId);
        }

        public OperationResult Delete(int modelId)
        {
            OperationResult op = new OperationResult("Delete", "Product", modelId);
            try
            {
                var item = Get(modelId);
                db.Products.Remove(item);
                db.SaveChanges();
                op.ToSuccess("Delete Successfully");
            }
            catch (Exception e)
            {
                op.ToFail("Delete Failed" + e.Message);
            }

            return op;
        }

        public OperationResult Add(ProductAddModel model)
        {
            OperationResult op = new OperationResult("Add", "Product");
            try
            {
                Product pr = new Product
                {
                    CategoryId = model.CategoryId,
                    SupplierId = model.SupplierId,
                    ProductName = model.ProductName,
                    Description = model.Description,
                    UnitPrice = model.UnitPrice,
                };
                if (model.CategoryId == -1)
                {
                    pr.CategoryId = null;
                }
                if (model.SupplierId == -1)
                {
                    pr.SupplierId = null;
                }
                db.Products.Add(pr);
                db.SaveChanges();
                op.RecordId = pr.ProductId;
                op.ToSuccess("Add Successfully", pr.ProductId);
            }
            catch (Exception e)
            {
                op.ToFail("Add Failed"+ e.Message);
            }

            return op;
        }

        public OperationResult Update(ProductUpdateModel model)
        {
            OperationResult op = new OperationResult("Update", "Product", model.ProductId);
            try
            {
                var item = Get(model.ProductId);
                item.ProductId = model.ProductId;
                item.ProductName = model.ProductName;
                item.Description = model.Description;
                item.UnitPrice = model.UnitPrice;
                db.SaveChanges();
                op.ToSuccess("Update Successfully");
            }
            catch (Exception e)
            {
                op.ToFail("Update Failed" + e.Message);
            }

            return op;
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public List<ProductListItem> Search(ProductSearchModel sm, out int recordCount)
        {
            var items = from item in db.Products select item;
            if (!string.IsNullOrEmpty(sm.ProductName))
            {
                items = items.Where(x => x.ProductName.StartsWith(sm.ProductName));
            }

            if (sm.MaxUnitPrice > 0)
            {
                items = items.Where(x => x.UnitPrice >= sm.MaxUnitPrice);
            }

            if (sm.MinUnitPrice > 0)
            {
                items = items.Where(x => x.UnitPrice <= sm.MinUnitPrice);
            }

            if (sm.CategoryId == -1)
            {
                sm.CategoryId = null;
            }

            if (sm.CategoryId != null)
            {
                items = items.Where(x => x.CategoryId == sm.CategoryId);
            }

            if (sm.SupplierId == -1)
            {
                sm.SupplierId = null;
            }

            if (sm.SupplierId != null)
            {
                items = items.Where(x => x.SupplierId == sm.SupplierId);
            }

            recordCount = items.Count();
            return items.Select(x => new ProductListItem
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                Description = x.Description,
                CategoryName = x.Category.CategoryName,
                SupplierName = x.Supplier.SupplierName
            }).OrderByDescending(x => x.ProductId).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public bool HasProductNameExist(string productName)
        {
            return db.Products.Any(x => x.ProductName == productName);
        }

        public bool HasProductNameExist(string productName, int productId)
        {
            return db.Products.Any(x => x.ProductName == productName && x.ProductId != productId);
        }

        public void AssignImageToProduct(Product product)
        {
            //OperationResult op = new OperationResult("AddImage", "Product", product.ProductId);
            //try
            //{
                if (product.ProductImages != null && product.ProductImages.Any())
                {
                    foreach (ProductImage pa in product.ProductImages)
                    {
                        db.ProductImages.Add(pa);
                    }
                }
                db.SaveChanges();
            //    op.ToSuccess("Add Image Successfully");
            //}
            //catch (Exception e)
            //{
            //    op.ToFail("Add Image Failed");
            //}
        }

        public List<ProductImage> GetImageList(int productId)
        {
            return db.ProductImages.Where(x => x.ProductId == productId).ToList();
        }
    }
}