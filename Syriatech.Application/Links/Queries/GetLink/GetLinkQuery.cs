using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Links.Queries.GetLink
{
    public class GetLinkQuery : IRequest<LinkViewModel>
    {
        public int Id { get; set; }
    }
}
