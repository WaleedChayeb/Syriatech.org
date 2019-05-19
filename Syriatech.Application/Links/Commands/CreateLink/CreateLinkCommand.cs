using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Links.Commands.CreateLink
{
    public class CreateLinkCommand : IRequest<int>
    { 
        public string Type { get; set; }
        public string Value { get; set; } 
        public string CreatedBy { get; set; }
    }
}
