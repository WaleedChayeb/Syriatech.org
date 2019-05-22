using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syriatech.Application.Events.Queries.GetAllEvents;

namespace Syriatech.WebUI.Controllers
{
    public class EventsController : NormalBaseController
    {
        public async Task<IActionResult> Index()
        {
            var events = new EventsListViewModel();
            try
            {

                var result = Ok(await Mediator.Send(new GetAllEventsQuery()));
                events = ((EventsListViewModel)result.Value);


            }
            catch (Exception e)
            {

            }

            return View(events);
        }
    }
}