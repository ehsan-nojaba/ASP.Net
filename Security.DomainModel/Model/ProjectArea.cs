using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DomainModel.Model
{
    public class ProjectArea
    {
        public int ProjectAreaId { get; set; }
        public string ProjectAreaName { get; set; }
        public string PersianTitle { get; set; }
        public ICollection<ProjectController> ProjectControllers { get; set; }

        public ProjectArea()
        {
            ProjectControllers = new List<ProjectController>();
        }
    }
}
