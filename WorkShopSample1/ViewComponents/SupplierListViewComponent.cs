using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract;
using Shopping.DomainModel.DTO.Supplier;

namespace WorkShopSample1.ViewComponents
{
    [ViewComponent(Name = "SupplierList")]
    public class SupplierListViewComponent:ViewComponent
    {
        private ISupplierBuss buss;

        public SupplierListViewComponent(ISupplierBuss buss)
        {
            this.buss = buss;
        }

        public IViewComponentResult Invoke(SupplierSearchModel sm)
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