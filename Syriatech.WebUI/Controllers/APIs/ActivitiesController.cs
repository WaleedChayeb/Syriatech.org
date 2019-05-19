using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syriatech.Application.Events.Commands.CreateEvent;
using Syriatech.Application.Events.Commands.DeleteEvent;
using Syriatech.Application.Events.Commands.UpdateEvent;
using Syriatech.Application.Events.Queries.GetAllEvents;
using Syriatech.Application.Events.Queries.GetEvent;

namespace Syriatech.WebUI.Controllers
{
    public class ActivitiesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<EventsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllEventsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventViewModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetEventQuery { Id = id }));
        }

    }
}