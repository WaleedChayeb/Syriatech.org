using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Projects.Queries.GetAllProjects
{
    public class ProjectsListViewModel
    {
        public IEnumerable<ProjectDto> Projects { get; set; }
        public bool CreateEnabled { get; set; }
    }
}
