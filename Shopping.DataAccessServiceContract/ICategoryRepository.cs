using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.DataAccess;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.Model;

namespace Shopping.DataAccessServiceContract
{
    public interface ICategoryRepository:IBaseSearchRepository<int , Category , CategorySearchModel , CategoryListItem , CategoryAddModel , CategoryUpdateModel>
    {
        int ProductCount(int categoryId);
        int ChildCount(int categoryId);
        bool HasProduct(int categoryId);
        bool HasChild(int categoryId);
        bool HasCategoryNameExist(string categoriesName);
        bool HasCategoryNameExist(string categoriesName , int categoryId);
        bool HasSlugExist(string slug);
        bool HasSlugExist(string slug , int categoryId);
        List<CategoryListItem> GetAllRoots();
    }
}