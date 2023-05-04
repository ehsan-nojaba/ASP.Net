using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.BusinessServiceContract;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.DTO.Product;
using Shopping.DomainModel.DTO.Supplier;

namespace WorkShopSample1.Controllers
{
    public class ProductController : Controller
    {
        private ICategoryBuss CatBuss;
        private ISupplierBuss SupBuss;
        private IProductBuss ProBuss;

        public ProductController(ICategoryBuss catBuss, ISupplierBuss supBuss, IProductBuss proBuss)
        {
            CatBuss = catBuss;
            SupBuss = supBuss;
            ProBuss = proBuss;
        }

        public void CategoryDrop()
        {
            var firsSelect = CatBuss.GetAllRoots();
            firsSelect.Insert(0,new CategoryListItem{CategoryId = -1 , CategoryName = "---دسته را انتخاب کنید---"});
            SelectList ctr = new SelectList(firsSelect, "CategoryId", "CategoryName");
            ViewBag.ctr = ctr;
        }

        public void SupplierDrop()
        {
            var secondSelect = SupBuss.GetAllRoots();
            secondSelect.Insert(0,new SupplierListItem{SupplierId = -1 , SupplierName = "---تولید کننده انتخاب کنید---"});
            SelectList sup = new SelectList(secondSelect, "SupplierId", "SupplierName");
            ViewBag.sup = sup;
        }

        public IActionResult Index(ProductSearchModel sm)
        {
            CategoryDrop();
            SupplierDrop();
            return View(sm);
        }

        public IActionResult AddNew()
        {
            return ViewComponent("ProductAdd");
        }

        [HttpPost]
        public JsonResult AddNew(ProductAddModel model)
        {
            var item = ProBuss.Register(model);
            return Json(item);
        }

        public IActionResult ListView(ProductSearchModel sm)
        {
            return ViewComponent("ProductList",sm);
        }

        [HttpPost]
        public JsonResult DeleteModel(int id)
        {
            var item = ProBuss.Remove(id);
            return Json(item);
        }
    }
}