using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork;
using Shopping.DataAccessServiceContract;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.Model;

namespace Shopping.DataAccess
{
    public class CategoryRepository:ICategoryRepository
    {
        private WorkShopDevelopContext db;

        public CategoryRepository(WorkShopDevelopContext db)
        {
            this.db = db;
        }

        public Category Get(int modelId)
        {
            return db.Categories.FirstOrDefault(x => x.CategoryId == modelId);
        }

        public OperationResult Delete(int modelId)
        {
            OperationResult op = new OperationResult("Delete", "Category", modelId);
            try
            {
                var item = Get(modelId);
                db.Categories.Remove(item);
                db.SaveChanges();
                op.ToSuccess("Delete Successfully");
            }
            catch (Exception e)
            {
                op.ToFail("Delete Failed"+ e.Message);
            }

            return op;
        }

        public OperationResult Add(CategoryAddModel model)
        {
            OperationResult op = new OperationResult("Add", "Category");
            try
            {
                Category ca = new Category
                {
                    CategoryName = model.CategoryName,
                    ParentId = model.ParentId,
                    Description = model.Description,
                    Slug = model.Slug,
                    MenuIcon = model.MenuIcon,
                };
                if (model.ParentId == -1)
                {
                    ca.ParentId = null;
                }
                db.Categories.Add(ca);
                db.SaveChanges();
                op.RecordId = ca.CategoryId;
                op.ToSuccess("Add Successfully", ca.CategoryId);
            }
            catch (Exception e)
            {
                op.ToFail("Add Failed" + e.Message);
            }
            return op;
        }

        public OperationResult Update(CategoryUpdateModel model)
        {
            OperationResult op = new OperationResult("Update", "Category", model.CategoryId);
            try
            {
                var item = Get(model.CategoryId);
                item.CategoryId = model.CategoryId;
                item.CategoryName = model.CategoryName;
                item.Description = model.Description;
                item.Slug = model.Slug;
                item.MenuIcon = model.MenuIcon;
                db.SaveChanges();
                op.ToSuccess("Update Successfully");
            }
            catch (Exception e)
            {
                op.ToFail("Update Failed" + e.Message);
            }
            return op;
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public List<CategoryListItem> Search(CategorySearchModel sm, out int recordCount)
        {
            var items = from item in db.Categories select item;
            if (sm.ParentId == -1)
            {
                sm.ParentId = null;
            }

            if (sm.ParentId != null)
            {
                items = items.Where(x => x.ParentId == sm.ParentId);
            }

            if (!string.IsNullOrEmpty(sm.CategoryName))
            {
                items = items.Where(x => x.CategoryName.StartsWith(sm.CategoryName));
            }
            recordCount = items.Count();
            return items.Select(x => new CategoryListItem
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                HasChild = x.Children.Any(),
                ProductCount = x.Products.Any() ? x.Products.Count() : 0,
            }).OrderByDescending(x => x.CategoryId).Skip(sm.PageSize * sm.PageIndex).Take(sm.PageSize).ToList();
        }

        public int ProductCount(int categoryId)
        {
            return db.Products.Count(x => x.CategoryId == categoryId);
        }

        public int ChildCount(int categoryId)
        {
            return db.Categories.Count(x => x.ParentId == categoryId);
        }

        public bool HasProduct(int categoryId)
        {
            return db.Products.Any(x => x.CategoryId == categoryId);
        }

        public bool HasChild(int categoryId)
        {
            return db.Categories.Any(x => x.ParentId == categoryId);
        }

        public bool HasCategoryNameExist(string categoriesName)
        {
            return db.Categories.Any(x => x.CategoryName == categoriesName);
        }

        public bool HasCategoryNameExist(string categoriesName, int categoryId)
        {
            return db.Categories.Any(x => x.CategoryName == categoriesName && x.CategoryId != categoryId);
        }

        public bool HasSlugExist(string slug)
        {
            return db.Categories.Any(x => x.Slug == slug);
        }

        public bool HasSlugExist(string slug, int categoryId)
        {
            return db.Categories.Any(x => x.Slug == slug && x.CategoryId != categoryId);
        }

        public List<CategoryListItem> GetAllRoots()
        {
            return db.Categories.Where(x => x.ParentId == null).Select(x => new CategoryListItem
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
            }).OrderBy(x => x.CategoryName).ToList();
        }
    }
}
