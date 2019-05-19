using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Events.Queries.GetAllEvents
{
    public class EventsListViewModel
    {
        public IEnumerable<EventDto> Events { get; set; }
        public bool CreateEnabled { get; set; }
    }
}
