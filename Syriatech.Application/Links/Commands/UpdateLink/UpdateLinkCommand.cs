using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Links.Commands.UpdateLink
{
    public class UpdateLinkCommand: IRequest
    {
        public int LinkId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; } 

    }
}
