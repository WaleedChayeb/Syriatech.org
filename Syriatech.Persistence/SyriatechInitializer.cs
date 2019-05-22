using Syriatech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq; 


namespace Syriatech.Persistence
{
   public class SyriatechInitializer
    {
        public static void Initialize(SyriatechDbContext context)
        {
            var initializer = new SyriatechInitializer();
            initializer.SeedEverything(context);
        }
        public void SeedEverything(SyriatechDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Events.Any())
            {
                return; 
            } 
            SeedEvents(context);

            if (context.Projects.Any())
            {
                return;
            }
            SeedProjects(context);

            if (context.Links.Any())
            {
                return;
            }
            SeedLinks(context);

            if (context.Users.Any())
            {
                return;
            }
            SeedUsers(context);
        }

        private void SeedEvents(SyriatechDbContext context)
        {
            var events = new[]
            { 
                new Event {  EventId = 1, Title = "Wordpress Meetup 1", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque tempus tortor risus, id viverra ligula rutrum et. Morbi ultricies mi id magna pharetra condimentum. Mauris sem turpis, tempor vitae urna vel, mollis interdum erat. Cras vel augue non leo sollicitudin feugiat vitae ac justo. Donec cursus pulvinar lobortis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque nec tortor nisl. Donec pellentesque pretium ipsum sed aliquam. Nunc placerat orci vitae massa accumsan pellentesque. Ut consectetur ante ut ex convallis, quis tempor sem molestie. Sed vel iaculis odio. Praesent nec est fringilla, posuere nunc quis, mollis massa. Morbi ullamcorper urna quis libero laoreet interdum. Fusce condimentum vestibulum eros, eu faucibus dolor maximus quis. " , StartDate = DateTime.Now.AddDays(2) , EndDate = DateTime.Now.AddDays(3), Organizer = "Syriatech Community" , Url = "http://syriatech.org/events", CreateDate = DateTime.Now},
                new Event {  EventId = 2, Title = "Facebook Developer Circle", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque tempus tortor risus, id viverra ligula rutrum et. Morbi ultricies mi id magna pharetra condimentum. Mauris sem turpis, tempor vitae urna vel, mollis interdum erat. Cras vel augue non leo sollicitudin feugiat vitae ac justo. Donec cursus pulvinar lobortis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque nec tortor nisl. Donec pellentesque pretium ipsum sed aliquam. Nunc placerat orci vitae massa accumsan pellentesque. Ut consectetur ante ut ex convallis, quis tempor sem molestie. Sed vel iaculis odio. Praesent nec est fringilla, posuere nunc quis, mollis massa. Morbi ullamcorper urna quis libero laoreet interdum. Fusce condimentum vestibulum eros, eu faucibus dolor maximus quis. " , StartDate = DateTime.Now.AddDays(2) , EndDate = DateTime.Now.AddDays(3), Organizer = "Syriatech Community" , Url = "http://syriatech.org/events", CreateDate = DateTime.Now},
                new Event {  EventId = 3, Title = "Wordpress Meetup 2", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque tempus tortor risus, id viverra ligula rutrum et. Morbi ultricies mi id magna pharetra condimentum. Mauris sem turpis, tempor vitae urna vel, mollis interdum erat. Cras vel augue non leo sollicitudin feugiat vitae ac justo. Donec cursus pulvinar lobortis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque nec tortor nisl. Donec pellentesque pretium ipsum sed aliquam. Nunc placerat orci vitae massa accumsan pellentesque. Ut consectetur ante ut ex convallis, quis tempor sem molestie. Sed vel iaculis odio. Praesent nec est fringilla, posuere nunc quis, mollis massa. Morbi ullamcorper urna quis libero laoreet interdum. Fusce condimentum vestibulum eros, eu faucibus dolor maximus quis. " , StartDate = DateTime.Now.AddDays(2) , EndDate = DateTime.Now.AddDays(3), Organizer = "Syriatech Community" , Url = "http://syriatech.org/events", CreateDate = DateTime.Now},
                new Event {  EventId = 4, Title = "Tech Crunch Syria", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque tempus tortor risus, id viverra ligula rutrum et. Morbi ultricies mi id magna pharetra condimentum. Mauris sem turpis, tempor vitae urna vel, mollis interdum erat. Cras vel augue non leo sollicitudin feugiat vitae ac justo. Donec cursus pulvinar lobortis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque nec tortor nisl. Donec pellentesque pretium ipsum sed aliquam. Nunc placerat orci vitae massa accumsan pellentesque. Ut consectetur ante ut ex convallis, quis tempor sem molestie. Sed vel iaculis odio. Praesent nec est fringilla, posuere nunc quis, mollis massa. Morbi ullamcorper urna quis libero laoreet interdum. Fusce condimentum vestibulum eros, eu faucibus dolor maximus quis. " , StartDate = DateTime.Now.AddDays(2) , EndDate = DateTime.Now.AddDays(3), Organizer = "Syriatech Community" , Url = "http://syriatech.org/events", CreateDate = DateTime.Now},
            };

            context.Events.AddRange(events); 
            context.SaveChanges();
        }


        private void SeedUsers(SyriatechDbContext context)
        {
            var users = new[]
            {
                new User { BestProject = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",  Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." , City = "Aleppo", Country = "Syria", Dob =DateTime.Now, Email = "test@test.com" , EmailConfirmed = true, FirstName = "First Name" , Gender = "Male", Id = Guid.NewGuid().ToString(), Interests = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." , LastName = "Last Name" , Major = 1, Picture = null, YearsOfExperience = 6, Published = true, UserName = "testuser", Title = "Test User", Skills = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", PasswordHash = "AQAAAAEAACcQAAAAENzmCBuVmSsd1ONkPYmXRq4kRZkek70syLfpxHRZk1xyoniawSHsxlYVHmV03X5DVg==" , SecurityStamp = "UCWMMZ4WSQLEOPABQ7IVURWZHXXBDJOO", ConcurrencyStamp = "27e97d6b-9811-44d5-b4cc-42fbd416fbe7", NormalizedEmail ="TEST@TEST.COM", NormalizedUserName = "Test User" }

            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private void SeedProjects(SyriatechDbContext context)
        {
            var projects = new[]
            {
                new Project {   ProjectId = 1,  Title = "Project 1", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque tempus tortor risus, id viverra ligula rutrum et. Morbi ultricies mi id magna pharetra condimentum. Mauris sem turpis, tempor vitae urna vel, mollis interdum erat. Cras vel augue non leo sollicitudin feugiat vitae ac justo. Donec cursus pulvinar lobortis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque nec tortor nisl. Donec pellentesque pretium ipsum sed aliquam. Nunc placerat orci vitae massa accumsan pellentesque. Ut consectetur ante ut ex convallis, quis tempor sem molestie. Sed vel iaculis odio. Praesent nec est fringilla, posuere nunc quis, mollis massa. Morbi ullamcorper urna quis libero laoreet interdum. Fusce condimentum vestibulum eros, eu faucibus dolor maximus quis. " , Url = "http://syriatech.org/LoveSyria", CreateDate = DateTime.Now, CreateBy = "testuser"},
                new Project {   ProjectId = 2,  Title = "Project 2", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque tempus tortor risus, id viverra ligula rutrum et. Morbi ultricies mi id magna pharetra condimentum. Mauris sem turpis, tempor vitae urna vel, mollis interdum erat. Cras vel augue non leo sollicitudin feugiat vitae ac justo. Donec cursus pulvinar lobortis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque nec tortor nisl. Donec pellentesque pretium ipsum sed aliquam. Nunc placerat orci vitae massa accumsan pellentesque. Ut consectetur ante ut ex convallis, quis tempor sem molestie. Sed vel iaculis odio. Praesent nec est fringilla, posuere nunc quis, mollis massa. Morbi ullamcorper urna quis libero laoreet interdum. Fusce condimentum vestibulum eros, eu faucibus dolor maximus quis. " , Url = "http://syriatech.org/LoveSyria", CreateDate = DateTime.Now, CreateBy = "testuser"},
                new Project {   ProjectId = 3,  Title = "Project 3", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque tempus tortor risus, id viverra ligula rutrum et. Morbi ultricies mi id magna pharetra condimentum. Mauris sem turpis, tempor vitae urna vel, mollis interdum erat. Cras vel augue non leo sollicitudin feugiat vitae ac justo. Donec cursus pulvinar lobortis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque nec tortor nisl. Donec pellentesque pretium ipsum sed aliquam. Nunc placerat orci vitae massa accumsan pellentesque. Ut consectetur ante ut ex convallis, quis tempor sem molestie. Sed vel iaculis odio. Praesent nec est fringilla, posuere nunc quis, mollis massa. Morbi ullamcorper urna quis libero laoreet interdum. Fusce condimentum vestibulum eros, eu faucibus dolor maximus quis. " , Url = "http://syriatech.org/LoveSyria", CreateDate = DateTime.Now, CreateBy = "testuser"},
                new Project {   ProjectId = 4,  Title = "Project 4", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque tempus tortor risus, id viverra ligula rutrum et. Morbi ultricies mi id magna pharetra condimentum. Mauris sem turpis, tempor vitae urna vel, mollis interdum erat. Cras vel augue non leo sollicitudin feugiat vitae ac justo. Donec cursus pulvinar lobortis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque nec tortor nisl. Donec pellentesque pretium ipsum sed aliquam. Nunc placerat orci vitae massa accumsan pellentesque. Ut consectetur ante ut ex convallis, quis tempor sem molestie. Sed vel iaculis odio. Praesent nec est fringilla, posuere nunc quis, mollis massa. Morbi ullamcorper urna quis libero laoreet interdum. Fusce condimentum vestibulum eros, eu faucibus dolor maximus quis. " , Url = "http://syriatech.org/LoveSyria", CreateDate = DateTime.Now, CreateBy = "testuser"},

            };

            context.Projects.AddRange(projects);
            context.SaveChanges();
        }

        private void SeedLinks(SyriatechDbContext context)
        {
            var links = new[]
            {
                new Link { LinkId = 1, Value = "https://google.com", Type="1",  CreatedBy = "testuser", CreateDate = DateTime.Now},
              new Link { LinkId = 2, Value = "https://google.com", Type="2",  CreatedBy = "testuser", CreateDate = DateTime.Now},
              new Link { LinkId = 3, Value = "https://google.com", Type="3",  CreatedBy = "testuser", CreateDate = DateTime.Now},
              new Link { LinkId = 4, Value = "https://google.com", Type="4",  CreatedBy = "testuser", CreateDate = DateTime.Now},
            };

            context.Links.AddRange(links);
            context.SaveChanges();
        }
    }
}
