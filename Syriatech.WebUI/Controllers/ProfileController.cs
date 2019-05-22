using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Syriatech.Application.Links.Queries.GetAllLinks;
using Syriatech.Application.Links.Queries.GetLink;
using Syriatech.Application.Majors;
using Syriatech.Application.Users.Queries.GetAllUsers;
using Syriatech.Application.Users.Queries.GetUser;

namespace Syriatech.WebUI.Controllers
{
    public class ProfileController : NormalBaseController
    {

        public async Task<IActionResult> Index(string id)
        {
            GetMajors nm = new GetMajors();
            ViewData["majors"] = nm.All();

            var users =  Ok(await Mediator.Send(new GetUserQuery { Username = id}));
            var links = Ok(await Mediator.Send(new GetAllLinksQuery {  Username = id }));

            //var Profile = new ProfileModel
            //{
            //    BestProject = user.BestProject,
            //    Bio = user.Bio,
            //    City = user.City,
            //    Country = user.Country,
            //    Dob = user.Dob,
            //    Email = user.Email,
            //    FirstName = user.FirstName,
            //    Gender = user.Gender,
            //    Interests = user.Interests,
            //    LastName = user.LastName,
            //    Major = user.Major,
            //    Picture = user.Picture,
            //    Skills = user.Skills,
            //    Title = user.Title,
            //    YearsOfExperience = user.YearsOfExperience

            //};
            //Profile.Links = new List<Links>();

            //foreach (var link in links)
            //{
            //    Profile.Links.Add(link);
            //}
            //return View(Profile);
            return View();
        }
    }
}