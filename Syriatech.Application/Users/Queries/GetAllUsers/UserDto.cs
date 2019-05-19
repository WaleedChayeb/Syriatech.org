using AutoMapper;
using Syriatech.Application.Interfaces.Mapping;
using Syriatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Users.Queries.GetAllUsers
{
    public class UserDto : IHaveCustomMapping
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int YearsOfExperience { get; set; }
        public int Major { get; set; }
        public string Title { get; set; }
        public string Bio { get; set; }
        public string Skills { get; set; }
        public string BestProject { get; set; }
        public string Interests { get; set; }
        public DateTime Dob { get; set; }
        public string Picture { get; set; }
        public bool Published { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<User, UserDto>();
        }
    }
}
