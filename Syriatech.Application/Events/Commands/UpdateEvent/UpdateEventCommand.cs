using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Events.Commands.UpdateEvent
{
    public class UpdateEventCommand: IRequest
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public string Url { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
