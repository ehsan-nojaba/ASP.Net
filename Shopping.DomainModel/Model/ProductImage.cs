using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.Model
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string Picture { get; set; }
        public string Alt { get; set; }
        public string Description { get; set; }
        public bool isDefault { get; set; }
        public Product Product { get; set; }
    }
}