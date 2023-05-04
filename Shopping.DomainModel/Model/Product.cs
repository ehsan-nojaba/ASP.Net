using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public long UnitPrice { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }

        public Product()
        {
            ProductImages = new List<ProductImage>();
        }
    }
}