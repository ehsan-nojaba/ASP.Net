using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DomainModel.Model
{
    public class RoleAction
    {
        public int RoleActionId { get; set; }
        public int ProjectActionId { get; set; }
        public int RoleId { get; set; }
        public bool HasPermission { get; set; }
        public ProjectAction ProjectAction { get; set; }
        public Role Role { get; set; }
    }
}
