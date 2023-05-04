using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.Supplier
{
    public class SupplierListItem
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Tel { get; set; }
        public long Grade { get; set; }
        public int ProductCount { get; set; }
    }
}