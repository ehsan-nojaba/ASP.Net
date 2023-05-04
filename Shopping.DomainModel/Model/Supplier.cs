using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.Model
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Tel { get; set; }
        public long Grade { get; set; }
        public ICollection<Product> Products { get; set; }

        public Supplier()
        {
            this.Products = new List<Product>();
        }
    }
}
