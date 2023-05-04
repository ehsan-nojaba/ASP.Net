using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int? ParentId { get; set; }
        public string CategoryName { get; set; }
        public string MenuIcon { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public Category Parent { get; set; }
        public ICollection<Category> Children { get; set; }
        public ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Children = new List<Category>();
            this.Products = new List<Product>();
        }
    }
}
