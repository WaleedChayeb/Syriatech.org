using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Domain.Entities
{
    public class User: IdentityUser
    {  
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
    }
}
