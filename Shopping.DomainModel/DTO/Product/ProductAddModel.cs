using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.Product
{
    public class ProductAddModel
    {
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public long UnitPrice { get; set; }
    }
}