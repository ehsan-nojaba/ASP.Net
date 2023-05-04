using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DomainModel.Model
{
    public class ProjectAction
    {
        public int ProjectActionId { get; set; }
        public int ProjectControllerId { get; set; }
        public string ProjectActionName { get; set; }
        public string PersianTitle { get; set; }
        public ProjectController ProjectController { get; set; }
        public ICollection<RoleAction> RoleActions { get; set; }

        public ProjectAction()
        {
            RoleActions = new List<RoleAction>();
        }
    }
}
