using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Events.Queries.GetEvent
{
    public class GetEventQuery : IRequest<EventViewModel>
    {
        public int Id { get; set; }
    }
}
