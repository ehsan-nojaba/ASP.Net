using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract;
using Shopping.DomainModel.DTO.Category;

namespace WorkShopSample1.ViewComponents
{
    [ViewComponent(Name = "CategoryList")]
    public class CategoryListViewComponent:ViewComponent
    {
        private ICategoryBuss buss;

        public CategoryListViewComponent(ICategoryBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke(CategorySearchModel sm)
        {
            if (sm == null || sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }

            var rc = 0;
            var item = buss.Search(sm, out rc);
            return View(item);
        }
    }
}