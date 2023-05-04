using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract;
using Shopping.DomainModel.DTO.Product;

namespace WorkShopSample1.ViewComponents
{
    [ViewComponent (Name = "ProductList")]
    public class ProductListViewComponent:ViewComponent
    {
        private IProductBuss buss;

        public ProductListViewComponent(IProductBuss buss)
        {
            this.buss = buss;
        }

        public IViewComponentResult Invoke(ProductSearchModel sm)
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