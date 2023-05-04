using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Domain;

namespace Shopping.DomainModel.DTO.Product
{
    public class ProductSearchModel:PageModel
    {
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public string ProductName { get; set; }
        public long MinUnitPrice { get; set; }
        public long MaxUnitPrice { get; set; }
    }
}