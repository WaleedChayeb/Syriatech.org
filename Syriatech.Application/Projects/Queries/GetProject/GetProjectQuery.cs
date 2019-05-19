using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Projects.Queries.GetProject
{
    public class GetProjectQuery : IRequest<ProjectViewModel>
    {
        public int Id { get; set; }
    }
}
