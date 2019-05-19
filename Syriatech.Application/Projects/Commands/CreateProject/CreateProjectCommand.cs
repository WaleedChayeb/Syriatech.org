using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    { 
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; } 
        public string CreateBy { get; set; }
    }
}
