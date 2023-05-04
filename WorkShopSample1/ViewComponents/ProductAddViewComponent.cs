using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.BusinessServiceContract;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.DTO.Supplier;

namespace WorkShopSample1.ViewComponents
{
    [ViewComponent(Name = "ProductAdd")]
    public class ProductAddViewComponent:ViewComponent
    {
        private ICategoryBuss CatBuss;
        private ISupplierBuss SupBuss;
        private IProductBuss ProBuss;

        public ProductAddViewComponent(ICategoryBuss catBuss, ISupplierBuss supBuss, IProductBuss proBuss)
        {
            CatBuss = catBuss;
            SupBuss = supBuss;
            ProBuss = proBuss;
        }

        public void CategoryDrop()
        {
            var firsSelect = CatBuss.GetAllRoots();
            firsSelect.Insert(0, new CategoryListItem { CategoryId = -1, CategoryName = "---دسته را انتخاب کنید---" });
            SelectList ctr = new SelectList(firsSelect, "CategoryId", "CategoryName");
            ViewBag.ctr = ctr;
        }

        public void SupplierDrop()
        {
            var secondSelect = SupBuss.GetAllRoots();
            secondSelect.Insert(0, new SupplierListItem { SupplierId = -1, SupplierName = "---تولید کننده انتخاب کنید---" });
            SelectList sup = new SelectList(secondSelect, "SupplierId", "SupplierName");
            ViewBag.sup = sup;
        }

        public IViewComponentResult Invoke()
        {
            CategoryDrop();
            SupplierDrop();
            return View();
        }
    }
}
