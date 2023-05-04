using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Domain;

namespace Shopping.DomainModel.DTO.Category
{
    public class CategorySearchModel:PageModel
    {
        public string CategoryName { get; set; }
        public int? ParentId { get; set; }
    }
}
