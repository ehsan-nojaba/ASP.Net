using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.Product
{
    public class ProductListItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public long UnitPrice { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
    }
}