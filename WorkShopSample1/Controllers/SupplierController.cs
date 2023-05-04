using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract;
using Shopping.DomainModel.DTO.Supplier;
using WorkShopSample1.Helper;

namespace WorkShopSample1.Controllers
{
    //[ServiceFilter(typeof(CustomAuthenticator))]
    public class SupplierController : Controller
    {
        private ISupplierBuss buss;

        public SupplierController(ISupplierBuss buss)
        {
            this.buss = buss;
        }
        public IActionResult Index(SupplierSearchModel sm)
        {
            return View(sm);
        }

        public IActionResult AddNew(SupplierSearchModel sm)
        {
            return ViewComponent("SupplierAdd", sm);
        }

        [HttpPost]
        public JsonResult AddNew(SupplierAddModel model)
        {
            var item = buss.Register(model);
            return Json(item);
        }

        public IActionResult ListActionResult(SupplierSearchModel sm)
        {
            return ViewComponent("SupplierList", sm);
        }

        [HttpPost]
        public JsonResult DeleteModel(int id)
        {
            var item = buss.Remove(id);
            return Json(item);
        }
    }
}