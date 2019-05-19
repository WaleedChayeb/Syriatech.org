using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<int>
    { 
        public string EventTitle { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public string Url { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } 
    }
}
