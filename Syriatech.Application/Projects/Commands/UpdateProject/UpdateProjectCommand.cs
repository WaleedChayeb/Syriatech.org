using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }  

    }
}
