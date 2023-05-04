using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.BusinessServiceContract;
using Shopping.DomainModel.DTO.Category;

namespace WorkShopSample1.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryBuss buss;

        public CategoryController(ICategoryBuss buss)
        {
            this.buss = buss;
        }

        public IActionResult Index(CategorySearchModel sm)
        {
            return View(sm);
        }

        public IActionResult AddNew()
        {
            return ViewComponent("CategoryAdd");
        }

        [HttpPost]
        public JsonResult AddNew(CategoryAddModel model)
        {
            var item = buss.Register(model);
            return Json(item);
        }

        public IActionResult ListView(CategorySearchModel sm)
        {
            return ViewComponent("CategoryList",sm);
        }

        public IActionResult SearchBoxView()
        {
            return ViewComponent("CategorySearchBox");
        }

        [HttpPost]
        public JsonResult DeleteView(int id)
        {
            var item = buss.Remove(id);
            return Json(item);
        }
    }
}