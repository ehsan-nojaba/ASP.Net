using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork;
using Shopping.BusinessServiceContract;
using Shopping.DataAccessServiceContract;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.Model;

namespace Shopping.Business
{
    public class CategoryBuss:ICategoryBuss
    {
        private ICategoryRepository repo;

        public CategoryBuss(ICategoryRepository repo)
        {
            this.repo = repo;
        }

        public OperationResult Remove(int id)
        {
            if (repo.ChildCount(id) > 0)
            {
                return new OperationResult("Remove", "Category").ToFail("This Category Has Related To Sub Category");
            }
            if (repo.HasProduct(id))
            {
                return new OperationResult("Remove", "Category").ToFail("This Category Has Related To Product");
            }

            return repo.Delete(id);
        }

        public OperationResult Register(CategoryAddModel model)
        {
            if (repo.HasCategoryNameExist(model.CategoryName))
            {
                return new OperationResult("Register", "Category").ToFail("This Category Name Exist Already");
            }
            if (repo.HasSlugExist(model.Slug))
            {
                return new OperationResult("Register", "Category").ToFail("This Slug Exist Already");
            }

            return repo.Add(model);
        }

        public OperationResult Update(CategoryUpdateModel model)
        {
            if (repo.HasCategoryNameExist(model.CategoryName , model.CategoryId))
            {
                return new OperationResult("Update" , "Category").ToFail("This Category Name Has Been Assigned to Another Category");
            }
            if (repo.HasSlugExist(model.Slug, model.CategoryId))
            {
                return new OperationResult("Update", "Category").ToFail("This Slug Has Been Assigned to Another Category");
            }
            return repo.Update(model);
        }

        public List<CategoryListItem> Search(CategorySearchModel sm, out int recordCount)
        {
            if (sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }

            return repo.Search(sm, out recordCount);
        }

        public List<CategoryListItem> GetAllRoots()
        {
            return repo.GetAllRoots();
        }

        public List<Category> GetAll()
        {
            return repo.GetAll();
        }

        public Category Get(int id)
        {
            return repo.Get(id);
        }
    }
}