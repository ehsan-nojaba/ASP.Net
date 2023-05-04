using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.BusinessServiceContract;
using Shopping.DomainModel.DTO.Category;

namespace WorkShopSample1.ViewComponents
{
    [ViewComponent(Name = "CategoryAdd")]
    public class CategoryAddViewComponent:ViewComponent
    {
        private ICategoryBuss buss;

        public CategoryAddViewComponent(ICategoryBuss buss)
        {
            this.buss = buss;
        }

        public void CategoryDropDown()
        {
            var firstSelect = buss.GetAllRoots();
            firstSelect.Insert(0, new CategoryListItem { CategoryId = -1, CategoryName = ".... انتخاب کنید ...." });
            SelectList ctr = new SelectList(firstSelect, "CategoryId", "CategoryName");
            ViewBag.ctr = ctr;
        }

        public IViewComponentResult Invoke()
        {
            CategoryDropDown();
            return View();
        }
    }
}