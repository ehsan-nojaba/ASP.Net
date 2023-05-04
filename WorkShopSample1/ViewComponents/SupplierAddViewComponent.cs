using Microsoft.AspNetCore.Mvc;
using Shopping.DomainModel.DTO.Supplier;

namespace WorkShopSample1.ViewComponents
{
    [ViewComponent(Name = "SupplierAdd")]
    public class SupplierAddViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}