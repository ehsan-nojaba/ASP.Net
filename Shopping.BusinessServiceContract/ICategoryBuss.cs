using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.Model;

namespace Shopping.BusinessServiceContract
{
    public interface ICategoryBuss
    {
        OperationResult Remove(int id);
        OperationResult Register(CategoryAddModel model);
        OperationResult Update(CategoryUpdateModel model);
        List<CategoryListItem> Search(CategorySearchModel sm, out int recordCount);
        List<CategoryListItem> GetAllRoots();
        List<Category> GetAll();
        Category Get(int id);
    }
}