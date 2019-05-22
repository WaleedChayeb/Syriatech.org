using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Syriatech.Application.Majors;
using Syriatech.Application.Users.Queries.GetAllUsers;
using Syriatech.WebUI.Models;

namespace Syriatech.WebUI.Controllers
{
    public class HomeController : NormalBaseController
    {
        public async Task<IActionResult> Index(int? type, int? pageNumber)
        {
            GetMajors nm = new GetMajors();
            ViewData["majors"] = nm.All();

            var profiles = new UsersListViewModel();
            try
            {

                var result = Ok(await Mediator.Send(new GetAllUsersQuery()));
                profiles = ((UsersListViewModel)result.Value);


            }
            catch (Exception e)
            {

            }

            int pageSize = 12; 
            return View(/*await PaginatedList<UsersListViewModel>.CreateAsync(profiles.Users.AsNoTracking(), pageNumber ?? 1, pageSize)*/);
        }
         
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
